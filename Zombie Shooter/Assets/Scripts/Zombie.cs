using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    Player player;
    NavMeshAgent navMeshAgent;
    CapsuleCollider capsuleCollider;
    Animator animator;
    MovementAnimator movementAnimator;
    bool dead;
    KillCounter kCount;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); //потому что плеер не потомок зомби, они никак не связаны
        navMeshAgent = GetComponent<NavMeshAgent>(); //потому что он находится в этом же объекте

        navMeshAgent.updateRotation = false;    //*

        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponentInChildren<Animator>();
        movementAnimator = GetComponent<MovementAnimator>();

        kCount = FindObjectOfType<KillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            return;
        }
        navMeshAgent.SetDestination(player.transform.position); //чтобы зомби шел к игроку

        transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized); //*
    }
    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            Destroy(capsuleCollider);
            Destroy(movementAnimator);
            Destroy(navMeshAgent);
            animator.SetTrigger("died");
            Destroy(gameObject, 3);
            GetComponentInChildren<ParticleSystem>().Play();
            kCount.AddKill();
        }
    }
}