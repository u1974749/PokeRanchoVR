using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject pokeball;
    [SerializeField] Pokeball pokeballScript;
    Vector3 RighHandPosition = new();
    void Start(){
        createPokeball();
        //addAllPokeballs();
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
