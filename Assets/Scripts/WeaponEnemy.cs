using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float delay;
    [SerializeField] float knockback;
    bool IsAttacking = false;
    Collider2D pl;
    float delayTime = 0f;
    void Start()
    {

    }
    public void Attack()
    {
        if (delayTime <= 0)
        {
            delayTime = delay;
            IsAttacking = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (delayTime > 0)
        {
            delayTime -= Time.deltaTime;
        }
        if (IsAttacking)
        {

            if (pl != null)
            {
                pl.GetComponent<HealthPlayer>().GetHit(damage);
            }
            IsAttacking = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pl = other;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pl = null;
        }

    }
}
