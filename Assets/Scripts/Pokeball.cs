using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

public class Pokeball : MonoBehaviour
{
    GameController gameController;
    [SerializeField] GameObject[] pokeballsPrefab;
    [SerializeField] GameObject player;
    //public TMP_Text nPokeball;
    public int numberPokeballs;
    public int totalPokeballs;

    private void Start()
    {
        numberPokeballs = totalPokeballs = pokeballsPrefab.Length;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            sustractPokeball();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            addAllPokeballs();
        }
        gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
    }

    public void sustractPokeball()
    {
        if (numberPokeballs > 0)
        {
            numberPokeballs -= 1;
            pokeballsPrefab[numberPokeballs].SetActive(false);
        }
        if (numberPokeballs == 0)
        {
            GameObject pokeball = GameObject.FindGameObjectWithTag("Pokeball");
            Destroy(pokeball);
            numberPokeballs -= 1;
        }
    }

    public int nPokeballs()
    {
        return numberPokeballs;
    }

    public void addAllPokeballs()
    {
        if(numberPokeballs == -1)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            gameController.createPokeball();
        }
        numberPokeballs = totalPokeballs;
        for (int i = 0; i < pokeballsPrefab.Length; i++)
        {
            pokeballsPrefab[i].SetActive(true);
            Debug.Log(i);
        }
    }
}
