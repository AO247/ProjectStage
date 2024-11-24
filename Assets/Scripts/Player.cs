using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movSpeed = 6f;
    [SerializeField] float acceleration = 10f; // Jak szybko postaæ siê rozpêdza
    [SerializeField] WeaponPlayer weapon0;
    [SerializeField] WeaponPlayer weapon1;
    [SerializeField] WeaponPlayer weapon2;
    [SerializeField] WeaponPlayer weapon3;
    [SerializeField] WeaponPlayer weapon4;
    [SerializeField] WeaponPlayer weapon;
    Rigidbody2D rb;
    SpriteRenderer rend;
    HealthPlayer health;
    Vector2 currentVelocity = Vector2.zero;
    float knockTime = 0f;
    float finishTime = 0f;
    Animator animator;

    LevelChange levelChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
      rend = rb.GetComponent<SpriteRenderer>();
      animator = GetComponent<Animator>();
      health = GetComponent<HealthPlayer>();

    }
    public void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = weapon1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = weapon2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = weapon3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weapon = weapon4;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!health.IsDead())
        {
            ChangeWeapon();
            if (finishTime > 0f)
            {
                finishTime -= Time.deltaTime;
                if (finishTime <= 0f)
                {

                }
            }
            else if (knockTime > 0f)
            {
                if (knockTime > 0.9f)
                {
                    knockTime -= Time.deltaTime;
                    rend.material.color = Color.red;
                }
                else
                {
                    rend.material.color = Color.white;

                }
                rb.linearVelocity *= new Vector2(0.98f, 0.98f);

                if (rb.linearVelocity.magnitude < 0.1f)
                {
                    knockTime = 0f;
                }

            }
            else
            {
                rend.material.color = Color.white;

                // Pobierz osie ruchu
                float inputX = Input.GetAxisRaw("Horizontal");
                float inputY = Input.GetAxisRaw("Vertical");
                if (Input.GetButtonDown("Fire1"))
                {
                    weapon.Attack();
                }
                if (!weapon.GetAttackStop())
                {
                    if(weapon.GetWeaponType() != -1)
                    {
                        animator.Play(weapon.GetWeaponType().ToString() + "_MOVE");
                    }
                    

                    //if (rb.linearVelocity != Vector2.zero)
                    //{
                    //    animator.Play(weapon.GetWeaponType().ToString() + "_MOVE");
                    //}
                    //else
                    //{
                    //    animator.Play(weapon.GetWeaponType().ToString() + "_CHILL");
                    //}
                }

                // Utwórz wektor kierunku
                Vector2 targetDirection = new Vector2(inputX, inputY);
                // Jeœli jest ruch (kierunek ró¿ny od (0,0)), normalizuj kierunek i pomnó¿ przez prêdkoœæ
                if (targetDirection.magnitude > 0)
                {
                    targetDirection = targetDirection.normalized * movSpeed;
                }
                currentVelocity = Vector2.Lerp(currentVelocity, targetDirection, acceleration * Time.deltaTime);

                rb.linearVelocity = currentVelocity;

                // Flipy dla renderera
                if (currentVelocity.x < 0)
                {
                    weapon.transform.rotation = Quaternion.Euler(0, 0, 180f);
                    rend.flipX = true;
                }
                else if (currentVelocity.x > 0)
                {
                    weapon.transform.rotation = Quaternion.Euler(0, 0, 0);
                    rend.flipX = false;
                }
            }
        }
    }
    public void Knockback(float knockback, Collider2D other)
    {
        knockTime = 1f;
        Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
        rb.AddForce(-knockbackDirection * knockback, ForceMode2D.Impulse);
    }
    public void Finisher()
    {
        finishTime = 1.5f;
        rb.linearVelocity = Vector2.zero;
        animator.Play("0_FINISH");

    }
    public float GetFinishTime()
    {
        return finishTime;
    }

    public Vector2 GetVelocity()
    {
        return rb.linearVelocity;
    }
}
