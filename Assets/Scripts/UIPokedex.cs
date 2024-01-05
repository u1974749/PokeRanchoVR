using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPokedex : MonoBehaviour
{
    //[SerializeField] List<RawImage> capture = new List<RawImage>();
    [SerializeField] List<Sprite> capture = new List<Sprite>();
    [SerializeField] List<Sprite> actualize = new List<Sprite>();
    [SerializeField] List<Sprite> pokemons = new List<Sprite>();
    public void Actualize()
    {
        for (int i = 0; i < capture.Count; i++)
            capture[i] = actualize[i];
            //capture[i].texture = actualize[i].texture;
    }
    public void obtainPokemon(string namePokemon)
    {
        bool founded = false;
        int i = 0;
        while (i < pokemons.Count && !founded)
        {
            Debug.Log("Capture: " + capture[i].name);
            Debug.Log("Pokemon: " + namePokemon);
            if (capture[i].name.ToUpper() == namePokemon.ToUpper())
            {
                founded = true;
                actualize[i] = pokemons[i];
            }
            else i++;
        }
        Actualize();
    }
}
