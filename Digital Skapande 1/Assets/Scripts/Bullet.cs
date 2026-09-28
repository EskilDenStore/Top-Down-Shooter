using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start() {
        Vector2 boundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if (Mathf.Abs(transform.position.x)>boundary.x || Mathf.Abs(transform.position.y)>boundary.y) {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            EnemyMovement enemyScript = collision.gameObject.GetComponent<EnemyMovement>();
            enemyScript.health--;
            if (enemyScript.health <= 0)
            {
                Destroy(collision.gameObject);
            }
 
            Color color = Color.HSVToRGB(0.2861f/4*(enemyScript.health-1), 0.57f, 0.75f);
            collision.gameObject.GetComponent<SpriteRenderer>().color = color;

            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}