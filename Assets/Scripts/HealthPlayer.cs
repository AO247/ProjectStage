using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField]
    private float currentHealth, maxHealth;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(float amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth == 0)
        {

            isDead = true;
        }

    }
}