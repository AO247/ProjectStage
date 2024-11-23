using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
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
    float delayTime = 0f;
    List<Collider2D> _enemies = new List<Collider2D>();    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].GetComponent<HealthEnemy>().GetHit(damage);
            }
            isAttacking = false;

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other);
        }
    }
}
