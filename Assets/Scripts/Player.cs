using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movSpeed = 6f;
    [SerializeField] float acceleration = 10f; // Jak szybko postaæ siê rozpêdza
    [SerializeField] WeaponPlayer weapon;
    Rigidbody2D rb;
    SpriteRenderer rend;
    Vector2 currentVelocity = Vector2.zero;
    float knockTime = 0f;
    float finishTime = 0f;
    Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
      rend = rb.GetComponent<SpriteRenderer>();
      animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (finishTime > 0f)
        {
            finishTime -= Time.deltaTime;
            if (finishTime <= 0f)
            {
                animator.SetBool("Finisher", false);
            }
        }

        else if (knockTime > 0f)
        {
            knockTime -= Time.deltaTime;
        }
        else
        {

            // Pobierz osie ruchu
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");
            if (Input.GetButtonDown("Fire1"))
            {
                weapon.Attack();
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
    public void Knockback(float knockback, Collider2D other)
    {
        knockTime = 0.5f;
        Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;
        rb.AddForce(-knockbackDirection * knockback, ForceMode2D.Impulse);
    }
    public void Finisher()
    {
        finishTime = 1.0f;
        rb.linearVelocity = Vector2.zero;
        animator.SetBool("Finisher", true);

    }
    public float GetFinishTime()
    {
        return finishTime;
    }
}
