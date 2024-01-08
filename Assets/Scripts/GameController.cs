using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pokeball;
    [SerializeField] Pokeball pokeballScript;
    [SerializeField] GameObject pokeballProjectile;
    [SerializeField] GameObject rightController;
    
    private Vector3 RighHandPosition = new();
    List<UnityEngine.XR.InputDevice> rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
    
    private bool gripL;
    private bool waited = true;
    
    private void Start(){
        
        createPokeball();
    }

    private void Update(){

        int nPokeballs = pokeballScript.nPokeballs();
        if (rightHandedControllers.Count <= 0)
        {
            var rdesiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
            UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(rdesiredCharacteristics, rightHandedControllers);
        }

        bool triggerValue;
        foreach (UnityEngine.XR.InputDevice device in rightHandedControllers)
        {
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && waited && nPokeballs > 0)
            {
                Vector3 pos = new Vector3(rightController.transform.position.x, rightController.transform.position.y, rightController.transform.position.z);
                pos += transform.forward;
                Instantiate(pokeballProjectile, pos, rightController.transform.rotation);
                waited = false;
                Invoke("Wait1Second", 1.0f);
                pokeballScript.sustractPokeball();
            }

        }
        if (Input.GetKeyDown("space") && nPokeballs > 0)
        {
            Vector3 pos = new Vector3(rightController.transform.position.x, rightController.transform.position.y, rightController.transform.position.z);
            pos += transform.forward;
            Instantiate(pokeballProjectile, pos, rightController.transform.rotation);
            waited = false;
            Invoke("Wait1Second", 1.0f);
            pokeballScript.sustractPokeball();

        }
    }

    private void Wait1Second()
    {
        waited = true;
    }

    public void createPokeball(){
        RighHandPosition = GameObject.FindGameObjectWithTag("RightHand").transform.position;
        Debug.Log("PositionHand"+RighHandPosition);
        Instantiate(pokeball, RighHandPosition, Quaternion.identity);
    }

    public void addAllPokeballs(){
        //GameObject pokeball_instantiate = GameObject.FindGameObjectWithTag("Pokeball").GetComponent<GameObject>();
        if(pokeballScript != null)
            pokeballScript.addAllPokeballs();
        //pokeballScript.addAllPokeballs();
    }
}
