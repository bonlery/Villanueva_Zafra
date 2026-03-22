using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    public float speed = 2f;
    public float patrolTime = 2f;
    public int oneTimeDamage = 20;
    private int direction = 1;
    private bool hasDamagedPlayer = false;

    void Start()
    {
        InvokeRepeating("SwitchDirection", patrolTime, patrolTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void SwitchDirection()
    {
        direction *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasDamagedPlayer && collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(oneTimeDamage);
                hasDamagedPlayer = true;
                Destroy(gameObject);
            }
        }
    }
}