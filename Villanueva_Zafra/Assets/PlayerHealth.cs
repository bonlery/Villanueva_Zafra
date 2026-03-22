using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText; 

    public void TakeDamage(int damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);
        Debug.Log("Health: " + health);

        if (healthText != null)
        {
            healthText.text = "Health: " + health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died");
        gameObject.SetActive(false);
    }
}