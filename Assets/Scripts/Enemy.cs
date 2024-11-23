using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movSpeed = 6f;
    [SerializeField] float acceleration = 10f;
    [SerializeField] WeaponEnemy weapon;

    Rigidbody2D rb;
    GameObject player;
    SpriteRenderer rend;
    HealthEnemy health;
    Collider2D coli;
    CircleCollider2D circleColi;
    Vector2 currentVelocity = Vector2.zero;
    bool finish;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        health = GetComponent<HealthEnemy>();
        coli = GetComponent<Collider2D>();
        circleColi = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (health.GetHP() > 0 )
        {
            //print(weapon.IsAttacking());
            coli.enabled = true;
            circleColi.enabled = false;
            if (weapon.GetPl() != null)
            {
                weapon.Attack();
            }
            if (!weapon.IsAttacking())
            {

                Vector2 targetDirection = (player.transform.position - transform.position);

                if (targetDirection.magnitude > 0.1f) // Ma³y margines dla unikniêcia drgañ
                {
                    targetDirection = targetDirection.normalized * movSpeed;
                }
                else
                {
                    targetDirection = Vector2.zero; // Obiekt przestaje siê poruszaæ, gdy jest wystarczaj¹co blisko gracza
                }

                currentVelocity = Vector2.Lerp(currentVelocity, targetDirection, acceleration * Time.deltaTime);

                rb.linearVelocity = currentVelocity;

                if (weapon != null)
                {
                    Vector2 lookDirection = player.transform.position - weapon.transform.position;
                    float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                    weapon.transform.rotation = Quaternion.Euler(0, 0, angle);
                }

                if (currentVelocity.x < 0)
                {
                    rend.flipX = true;
                }
                else if (currentVelocity.x > 0)
                {
                    rend.flipX = false;
                }
            }else
            {
               rb.linearVelocity = Vector2.zero;

            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            coli.enabled = false;
            circleColi.enabled = true;
            if(finish)
            {
                if (Input.GetButtonDown("Fire3") && !health.IsStanding())
                {
                    print("JEEEJ");
                    health.Dead();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            finish = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finish = false;
        }
    }
}
