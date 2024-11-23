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
    int weaponType = 0;

    GameObject player;
    Animator animator;

    float baTime = 0f;
    float aaTime = 0f;
    float delayTime = 0f;
    List<Collider2D> _enemies = new List<Collider2D>();    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }
    public void Attack()
    {
        if (delayTime <= 0 && !attackStop)
        {
            
            attackStop = true;
            baTime = beforeAttackTime;
            animator.SetBool("Atakowanie", true);
        }

    }

    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponType = 1;
            animator.SetInteger("Bron", weaponType);
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponType = 2;
            animator.SetInteger("Bron", weaponType);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponType = 3;
            animator.SetInteger("Bron", weaponType);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponType = 4;
            animator.SetInteger("Bron", weaponType);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ChangeWeapon();
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
            animator.SetBool("Atakowanie", false);

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
                _enemies[i].GetComponent<HealthEnemy>().GetHit(damage, knockback);
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
