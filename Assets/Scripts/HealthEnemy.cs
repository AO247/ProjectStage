using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float standingTime;


    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false;
    float sTime = 0f;
    float maxHealth;
    private void Start()
    {
        maxHealth = currentHealth;
    }
    private void Update()
    {
        if (currentHealth == 0)
        {
            if (sTime > 0f)
            {
                sTime -= Time.deltaTime;

            }
            if (sTime <= 0f)
            {
                transform.rotation *= Quaternion.Euler(0, 0, -90f);
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

    public void GetHit(float amount)
    {
        if (isDead)
            return;

        currentHealth -= amount;

        if (currentHealth == 0)
        {
            sTime = standingTime;
            transform.rotation *= Quaternion.Euler(0, 0, 90f);
            
        }
        else if (currentHealth < 0)
        {
            isDead = true;
        }

    }
}