using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonSpawn : MonoBehaviour
{
    [SerializeField] ListOfPokemon listOfPokemon;
    public GameObject[] spawnPoints;
    private GameObject[] allPkmn;

    private int Spawned = 0;
    // Start is called before the first frame update
    void Start()
    {
        allPkmn = listOfPokemon.allPokemon;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPokemon();
    }

    private void SpawnPokemon()
    {
        GameObject[] pokemonInScene = null;
        pokemonInScene = GameObject.FindGameObjectsWithTag("pokemon");
        if (pokemonInScene.Length < 7)
        {
            SpawnRandomPokemon();
        }
    }

    private void SpawnRandomPokemon()
    {
        int index = Random.Range(0, allPkmn.Length);
        int pos = Random.Range(0, 4);

        GameObject newPokemon = Instantiate(allPkmn[index], spawnPoints[pos].transform.position, Quaternion.identity);
        newPokemon.name = newPokemon.name.Replace("(Clone)", "");
        
    }

}
