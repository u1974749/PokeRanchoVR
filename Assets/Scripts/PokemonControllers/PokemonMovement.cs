using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PokemonMovement : MonoBehaviour
{
    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;
    private NavMeshAgent agent;
    private Animator animator;
    private bool endIdle = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        animator = GetComponent<Animator>();
        if(agent != null ) {
            agent.speed = speed;
            agent.SetDestination(RandomNavMeshLocation());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( agent != null  && agent.remainingDistance <= agent.stoppingDistance) {
            animator.SetBool("Idle", true);
            if(endIdle){
                animator.SetBool("Idle", false);
                agent.SetDestination(RandomNavMeshLocation());
                endIdle = false;
            }
        }
    }

    public Vector3 RandomNavMeshLocation() {
        Vector3 finalPos = Vector3.zero;
        Vector3 randomPos = Random.insideUnitSphere * walkRadius;
        randomPos += transform.position;

        if(NavMesh.SamplePosition(randomPos, out NavMeshHit hit, walkRadius, 1)) {
            finalPos = hit.position;
        }
        return finalPos;
    }

    public void EndAnimation() {
        endIdle = true;
    }

    public void IsCapturing() {
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);        
    }

    public void CaptureEnd(bool captured) {
        if(captured) {
            Destroy(gameObject);
        }
        else {
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);
        }
    }
}
