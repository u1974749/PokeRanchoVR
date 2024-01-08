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
    
    private Vector3 RighHandPosition = new();
    List<UnityEngine.XR.InputDevice> rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
    private bool gripL;
    
    private void Start(){
        
        createPokeball();


        //addAllPokeballs();
    }

    private void Update(){

        if (rightHandedControllers.Count <= 0)
        {
            var rdesiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
            UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(rdesiredCharacteristics, rightHandedControllers);
        }

        bool triggerValue;
        foreach (UnityEngine.XR.InputDevice device in rightHandedControllers)
        {
            if(device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
                //Instantiate()
                Debug.Log("pulsando");
        }
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
