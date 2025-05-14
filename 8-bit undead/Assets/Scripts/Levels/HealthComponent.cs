using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 10;
    private float currentHealth;

    public static event Action<GameObject> OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TowerToDefend")
        {
            GameManager.DecreaseLife(1);
            Destroy(gameObject);
        }
    }

    void Die()
    {
        OnDeath?.Invoke(gameObject);
        GameManager.IncreaseKills();
        Destroy(gameObject);
    }
}
