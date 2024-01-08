using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokedex : MonoBehaviour
{
    [SerializeField]  ListOfPokemon Public_pkmnList;
    [SerializeField]  GameObject Public_ranchSpawner;
    [SerializeField]  UIPokedex Public_UI;
 
    public static Dictionary<string, bool> pokedex { get; private set; } = new Dictionary<string, bool>();
    private static ListOfPokemon pkmnList;
    private static UIPokedex _uiPokedex;
    private static GameObject ranchSpawner;

    // Start is called before the first frame update
    void Start() {

        pkmnList = Public_pkmnList;
        ranchSpawner = Public_ranchSpawner;
        _uiPokedex = Public_UI;

        if(pkmnList != null) {
            GameObject[] allPokemons = pkmnList.allPokemon;
            for (int i = 0; i < allPokemons.Length; i++) {
                pokedex.Add(allPokemons[i].name, false);
            }

        }

    }

    public static bool IsPokemonCaptured(string pkmn) {
        if(pokedex.ContainsKey(pkmn)) {
            return true;
        }
        return false;
    }

    public static void CapturePokemon(string pkmn) {
        Debug.Log("hellou" + pkmn);
        if (pokedex.ContainsKey(pkmn)){
            pokedex[pkmn] = true;
            for(int i = 0; i < pkmnList.allPokemon.Length; i++)
            {
                if (pkmnList.allPokemon[i].name == pkmn)
                {
                    Instantiate(pkmnList.allPokemon[i], ranchSpawner.transform.position, Quaternion.identity);
                    _uiPokedex.obtainPokemon(pkmn);
                    break;
                }
            }
        }
    }
}
