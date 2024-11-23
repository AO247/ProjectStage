using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float delay;
    [SerializeField] float beforeAttackTime;
    [SerializeField] float afterAttackTime;
    [SerializeField] float knockback;
    bool isAttacking = false;
    bool attackStop = false;
    float baTime = 0f;
    float aaTime = 0f;
    Collider2D pl;
    float delayTime = 0f;
    void Start()
    {

    }
    public void Attack()
    {
        if (delayTime <= 0 && !attackStop)
        {
            attackStop = true;
            baTime = beforeAttackTime;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (baTime > 0)
        {
            baTime -= Time.deltaTime;
        }
        else if (baTime < 0 && attackStop == true)
        {
            isAttacking = true;
            aaTime = afterAttackTime;
            baTime = 0;
        }

        if (aaTime > 0)
        {
            aaTime -= Time.deltaTime;
        }
        else if (aaTime <= 0 && baTime == 0 && attackStop == true)
        {
            delayTime = delay;
            attackStop = false;
        }

        if (delayTime > 0)
        {
            delayTime -= Time.deltaTime;
        }
        if (isAttacking)
        {
            if (pl != null)
            {
                print("Strimke");
                pl.GetComponent<HealthPlayer>().GetHit(damage);
            }
            isAttacking = false;

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
    
    public Collider2D GetPl()
    {
        return pl;
    }
    public bool IsAttacking()
    {
        return attackStop;
    }
}
