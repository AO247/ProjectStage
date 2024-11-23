using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float standingTime;
    [SerializeField] Renderer pool;
    [SerializeField] ParticleSystem blood;
    [SerializeField] ParticleSystem hit;

    Enemy enemy;
    Animator animator;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false, isStanding = true;
    
    float sTime = 0f;
    float maxHealth;
    private void Start()
    {
        maxHealth = currentHealth;
        enemy = GetComponent<Enemy>();
        animator = enemy.GetComponent<Animator>();

    }
    private void Update()
    {
        if (currentHealth == 0 && !isDead)
        {
            if (sTime > 0f)
            {
                sTime -= Time.deltaTime;

            }
            if (sTime < 0.3f)
            {
                animator.SetBool("IsStanding", true);
            }
            if (sTime <= 0f)
            {
                isStanding = true;
                currentHealth = maxHealth;
               

            }
        }
    }
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(float amount, float knockback)
    {
        if (isDead)
            return;
        enemy.Knockback(knockback);
        if (currentHealth > 0)
        {
            hit.Play();
            currentHealth -= amount;
        }
        if (currentHealth <= 0)
        {
            sTime = standingTime;
            isStanding = false;
            animator.SetBool("IsStanding", false);
            animator.SetBool("Atakowanie", false);
            if(amount > 30)
            {
                Dead();
            }
        }

    }
    public void Dead()
    {
        isDead = true;
        pool.enabled = true;
        currentHealth = 0;
        isStanding = false;
        animator.SetBool("IsStanding", false);
        blood.Play();
    }

    public float GetHP()
    {
        return currentHealth;
    }
    public bool IsDead()
    {
        return isDead;
    }
    public bool IsStanding()
    {
        return isStanding;
    }

}