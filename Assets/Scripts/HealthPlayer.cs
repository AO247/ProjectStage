using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField]
    private float currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField] private bool isDead = false;
    Player player;
    private void Start()
    {
        player = GetComponent<Player>();

    }
    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(float amount, float knockback, Collider2D other)
    {
        if (isDead)
            return;
        if(currentHealth > 0)
        {
            if (player.GetFinishTime() <= 0)
            {
                currentHealth -= amount;
                player.Knockback(knockback, other);
                
            }

        }


        if (currentHealth == 0)
        {

            isDead = true;
        }

    }
    public float GetHP()
    {
        return currentHealth;
    }
    public bool IsDead()
    {
        return isDead;
    }
    
}