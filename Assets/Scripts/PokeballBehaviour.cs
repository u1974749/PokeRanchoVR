using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _shaking;
    [SerializeField] private AudioClip _captured;

    private Animator anim;
    private Rigidbody rb;
    private AudioSource audioSrc;
    private SkinnedMeshRenderer[] meshes;

    private bool pokemonCaptured;

    private bool shaking;
    private int timesToShake;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        audioSrc = gameObject.GetComponent<AudioSource>();
        meshes = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();

        pokemonCaptured = false;
    }

    private void Update()
    {
        if (shaking)
        {
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("PokeballShake"))
            {
                if (timesToShake > 0) anim.Play("PokeballShake", 0, -0.4f);
                timesToShake--;
            }
            if (timesToShake < 0)
            {
                shaking = false;
                if (pokemonCaptured) Invoke("FinnishCapture",0.5f);
                //else Invoke("PokemonEscaped",0.5f);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("pokemon"))
        {
        //  conseguir probabilidad
        //  calcular si ha sido capturado
        //  if capturado
            pokemonCaptured = true;
            ShakeAnimation(3);
        //else
        //{
        //  ShakeAnimation(intrandom)
        }
        else
        {
            Invoke("DestroyItself", 0.5f);
        }
    }

    private void ShakeAnimation(int nSakes)
    {
        rb.isKinematic = true;
        timesToShake = nSakes;
        audioSrc.clip = _shaking;
        audioSrc.Play();
        shaking = true;
    }

    private void FinnishCapture()
    {
        for (int i = 0; i < 3; i++)
        {
            meshes[i].material.color = Color.black;
        }
        audioSrc.clip = _captured;
        audioSrc.Play();
        Invoke("DestroyItself", 1.0f);
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
    }
}
