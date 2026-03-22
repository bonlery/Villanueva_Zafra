using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public int damage = 5;
    public float damageInterval = 0.05f;

    private GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            player = collision.gameObject;
            InvokeRepeating(nameof(DealDamage), 0f, damageInterval);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            CancelInvoke(nameof(DealDamage));
            player = null;
        }
    }

    void DealDamage()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}