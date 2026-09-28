using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public float interval = 3f;
    [SerializeField] public int batch = 1;
    [SerializeField] GameObject enemy;
    float cooldown = 0;
    Vector2 boundary;
    void Start()
    {
        boundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (cooldown>=interval) {
            for (int i = 0;i < batch;i++) {
                if (Random.Range(0, 2) == 1) {
                    Instantiate(enemy, new Vector2((Random.Range(0,2)*2-1)*boundary.x,Random.Range(-boundary.y,boundary.y)), Quaternion.identity);
                } else {
                    Instantiate(enemy, new Vector2(Random.Range(-boundary.x,boundary.x),(Random.Range(0,2)*2-1)*boundary.y), Quaternion.identity);
                }
                cooldown = 0;
            }
        }
    }
}
