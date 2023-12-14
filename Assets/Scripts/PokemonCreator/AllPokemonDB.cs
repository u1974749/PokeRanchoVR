using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class AllPokemonDB : MonoBehaviour
{
    public static AllPokemonDB Instance {  get; private set; }
    private static GameObject[] AllPokemon;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public static void SetAllPokemonList(GameObject[] pkmn)
    {
        AllPokemon = pkmn;
    }

}

