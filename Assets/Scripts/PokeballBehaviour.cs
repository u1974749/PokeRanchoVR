using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeballBehaviour : MonoBehaviour
{
    private Transform tf;
    private Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision other)
    {
        //if (other.gameObject.CompareTag("pokemon"))
        //{
        //conseguir probabilidad
        //calcular si ha sido capturado
        //if capturado
        CapturedAnimation();
        //else
        //EscapedAnimation();
        //}
        //gameObject.Destroy(itself);
    }

    private void CapturedAnimation()
    {
        rb.isKinematic = true;
        StartCoroutine(LittleShakesAnimation(3));
    }

    private void EscapedAnimation()
    {
        rb.isKinematic = true;
    }

    private IEnumerator LittleShakesAnimation(int nTimes)
    {
        Debug.Log("rot");
        Quaternion target = Quaternion.Euler(100, 0, 100);

        tf.rotation = Quaternion.Slerp(tf.rotation, target, Time.deltaTime * 5);
        yield return new WaitForSeconds(2);
        StartCoroutine(LittleShakesAnimation(nTimes - 1));
    }
}
