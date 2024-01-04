using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokedex : MonoBehaviour
{
    [SerializeField] ListOfPokemon pkmnList;
    public static Dictionary<string, bool> pokedex { get; private set; } = new Dictionary<string, bool>();

    // Start is called before the first frame update
    void Start() {

        if(pkmnList != null) {
            GameObject[] allPokemons = pkmnList.allPokemon;
            for (int i = 0; i < allPokemons.Length; i++) {
                Debug.Log(allPokemons[i].name);
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
        if (pokedex.ContainsKey(pkmn)){
            pokedex[pkmn] = true;
        }
    }
}
