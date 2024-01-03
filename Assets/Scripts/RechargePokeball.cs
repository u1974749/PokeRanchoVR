using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargePokeball : MonoBehaviour
{
    bool trigger = false;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Pokeball"))
            trigger = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Pokeball"))
            trigger = false;
    }

    public void recharge()
    {
        Debug.Log("Recharge without trigger");
        if (trigger)
        {
            Debug.Log("Recharge trigger!!");
            Pokeball pokeball = GameObject.FindGameObjectWithTag("Pokeball").GetComponent<Pokeball>();
            pokeball.addAllPokeballs();

        }
    }
}
