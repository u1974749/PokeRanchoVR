using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ListOfPokemon : MonoBehaviour
{
    private string pokemonFolder = "Prefab/Pokemon";

    void OnValidate()
    {
        string fullPath = $"{Application.dataPath}/{pokemonFolder}";
        if (!System.IO.Directory.Exists(fullPath))
        {
            return;
        }

        var folders = new string[] { $"Assets/{pokemonFolder}" };
        var guids = AssetDatabase.FindAssets("t:prefab", folders);

        var newPokemons = new GameObject[guids.Length];

        bool mismatch;
        if (allPokemon == null)
        {
            mismatch = true;
            allPokemon = newPokemons;
        }
        else
        {
            mismatch = newPokemons.Length != allPokemon.Length;
        }

        for (int i = 0; i < newPokemons.Length; i++)
        {
            var path = AssetDatabase.GUIDToAssetPath(guids[i]);
            newPokemons[i] = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            mismatch |= (i < allPokemon.Length && allPokemon[i] != newPokemons[i]);
        }

        if (mismatch)
        {
            allPokemon = newPokemons;
            Debug.Log($"{name} game object list updated.");
        }

        AllPokemonDB.SetAllPokemonList(allPokemon);
    }

    public GameObject[] allPokemon;
}
