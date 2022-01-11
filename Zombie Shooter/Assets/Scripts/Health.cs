using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public Slider slider;
    public Text healthPercent;

    NavMeshAgent navMeshAgent;
    CapsuleCollider capsuleCollider;
    Animator animator;
    MovementAnimator movementAnimator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
        movementAnimator = GetComponent<MovementAnimator>();
    }

    void Update()
    {
        slider.value = health;
        healthPercent.text = $"{health}%";
    }

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetTrigger("died");
            Destroy(capsuleCollider);
            Destroy(movementAnimator);
            Destroy(navMeshAgent);
            Destroy(gameObject, 2);
        }
    }
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health > maxHealth) health = maxHealth;
    }
}
