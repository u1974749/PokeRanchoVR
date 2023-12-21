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

        rb.AddForce(0, 5f, 5f, ForceMode.Impulse);
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
                else Invoke("FailedCapture",0.5f);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.isKinematic = true;
        if (other.gameObject.CompareTag("pokemon"))
        {
            float probability = 80.0f;//  conseguir probabilidad, de momento 80%
            float randomNumber = Random.Range(0.0f, 100.0f);

            if (randomNumber < probability) //capturado
            {
                Debug.Log("Pokemon Captured");
                pokemonCaptured = true;
                ShakeAnimation(3);
            }
            else
            {
                Debug.Log("Pokemon Escaped");
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
