using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehaviour : MonoBehaviour
{
    [SerializeField] private AudioClip _shaking;
    [SerializeField] private AudioClip _captured;
    [SerializeField] private Material _whiteMat;

    private Animator anim;
    private Rigidbody rb;
    private AudioSource audioSrc;
    private SkinnedMeshRenderer[] meshes;
    private PokemonMovement lastPokemon;
    private Haptic _haptic;

    private bool pokemonCaptured;

    private bool shaking;
    private int timesToShake;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponent<Animator>();
        audioSrc = gameObject.GetComponent<AudioSource>();
        meshes = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        _haptic = GameObject.FindObjectOfType<Haptic>();

        pokemonCaptured = false;

        rb.AddForce(transform.forward*10, ForceMode.Impulse);
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
                if (pokemonCaptured) Invoke("FinnishCapture", 0.5f);
                else
                {
                    Invoke("FailedCapture", 0.5f);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        rb.isKinematic = true;
        if (other.gameObject.CompareTag("pokemon"))
        {
            lastPokemon = other.gameObject.GetComponent<PokemonMovement>();
            int probability = 100;// probabilidad  80%
            int randomNumber = Random.Range(0, 100);

            lastPokemon.IsCapturing();
            if (randomNumber < probability) //capturado
            {
                pokemonCaptured = true;
                ShakeAnimation(3);
                Pokedex.CapturePokemon(other.gameObject.name);
            }
            else
            {
                ShakeAnimation(Random.Range(1, 3));
            }
        }
        else
        {
            FailedCapture();
        }
    }

    private void ShakeAnimation(int nSakes)
    {
        timesToShake = nSakes;
        audioSrc.clip = _shaking;
        audioSrc.Play();
        shaking = true;
    }

    private void FailedCapture()
    {
        for (int i = 0; i < 3; i++)
        {
            meshes[i].material = _whiteMat;
        }
        Invoke("DestroyItself", 1.0f);

        if(lastPokemon != null)
            lastPokemon.CaptureEnd(pokemonCaptured);

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
        lastPokemon.CaptureEnd(pokemonCaptured);
    }

    private void DestroyItself()
    {
        _haptic.right = true;
        Destroy(gameObject);
    }
}
