using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pokeball : MonoBehaviour
{
    public TMP_Text nPokeball;
    public int numberPokeballs;
    public int totalPokeballs;

    void Update(){
        numberPokeballUI();
    }
    public void numberPokeballUI()
    {
        nPokeball.text = (numberPokeballs).ToString();
    }

    public void sustractPokeball(){
        numberPokeballs -= 1;
    }

    public int nPokeballs(){
        return numberPokeballs;
    }

    public void addAllPokeballs(){
        numberPokeballs = totalPokeballs;
    }
}
