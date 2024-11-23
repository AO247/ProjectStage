using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float standingTime;
    [SerializeField] Enemy enemy;

    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    private bool isDead = false, isStanding = true;
    float sTime = 0f;
    float maxHealth;
    private void Start()
    {
        maxHealth = currentHealth;
        enemy = GetComponent<Enemy>();
    }
    private void Update()
    {
        if (currentHealth == 0 && !isDead)
        {
            if (sTime > 0f)
            {
                sTime -= Time.deltaTime;

            }
            if (sTime <= 0f)
            {
                isStanding = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if (currentHealth > 0)
        {
            currentHealth -= amount;
        }
        if (currentHealth == 0)
        {
            sTime = standingTime;
            transform.rotation = Quaternion.Euler(0, 0, 90f);
            isStanding = false;
        }

    }
    public void Dead()
    {
        isDead = true;
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