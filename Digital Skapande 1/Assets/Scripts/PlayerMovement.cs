using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 boundary;
    Vector2 moveInput;
    bool attacking = false;
    [SerializeField] public int health = 5;
    [SerializeField] float iFrames = 1f;
    float iFrameTime = 0;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float bulletSpeed = 7.5f;
    [SerializeField] float bulletCooldown = 0.4f;
    float bulletTime = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject Gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        attacking = !attacking;
    }
    // Update is called once per frame
    void Update()
    {
        bulletTime -= Time.deltaTime;
        iFrameTime -= Time.deltaTime;

        rb.AddForce(moveInput * moveSpeed);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -boundary.x, boundary.x),
                                         Mathf.Clamp(transform.position.y, -boundary.y, boundary.y));

        if (attacking && bulletTime <= 0) {
            Rigidbody2D playerBullet = Instantiate(bullet, Gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
            playerBullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
            bulletTime = bulletCooldown;
        }

        if (iFrameTime <= 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(170/255f, 64/255f, 131/255f);
        }
    }

    void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle - 90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && iFrameTime <= 0)
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }

            iFrameTime = iFrames;

            GetComponent<SpriteRenderer>().color = new Color(120/255f, 59/255f, 97/255f);
        }
    }
}
