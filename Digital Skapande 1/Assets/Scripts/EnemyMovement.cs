using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] public int health = 5;
    Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
        if (player != null) {
            direction = (player.position - transform.position).normalized;
        } else
        {
            direction = -(new Vector3(0,0,0) - transform.position).normalized;
        }

        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}
