using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movSpeed = 6f;
    [SerializeField] float acceleration = 10f; // Jak szybko posta� si� rozp�dza
    [SerializeField] WeaponPlayer weapon;
    Rigidbody2D rb;
    SpriteRenderer rend;
    Vector2 currentVelocity = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  
      rend = rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Pobierz osie ruchu
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Fire1"))
        {
            weapon.Attack();
        }
        // Utw�rz wektor kierunku
        Vector2 targetDirection = new Vector2(inputX, inputY);
        // Je�li jest ruch (kierunek r�ny od (0,0)), normalizuj kierunek i pomn� przez pr�dko��
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
