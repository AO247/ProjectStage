using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float delay;
    [SerializeField] float knockback;
    bool IsAttacking = false;
    float delayTime = 0f;
    List<Collider2D> _enemies = new List<Collider2D>();    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        print(_enemies.Count);
        if (delayTime > 0)
        {
            delayTime -= Time.deltaTime;
        }
        if (IsAttacking)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                _enemies[i].GetComponent<HealthEnemy>().GetHit(damage);
            }
            IsAttacking = false;

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
