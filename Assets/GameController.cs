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
        
    }
    public void createPokeball(){
        RighHandPosition = GameObject.FindGameObjectWithTag("RightHand").transform.position;
        Debug.Log("PositionHand"+RighHandPosition);
        Instantiate(pokeball, RighHandPosition, Quaternion.identity);
        addAllPokeballs();
    }

    public void addAllPokeballs(){
        //GameObject pokeball_instantiate = GameObject.FindGameObjectWithTag("Pokeball").GetComponent<GameObject>();
        //pokeball_instantiate.GetComponent<Pokeball>().addAllPokeballs();
        //pokeballScript.addAllPokeballs();
    }
}
