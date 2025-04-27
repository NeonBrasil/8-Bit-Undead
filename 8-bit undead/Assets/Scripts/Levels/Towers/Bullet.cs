using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f;
    public float speed = 10f;
    public GameObject target;
    public Vector3 direcao;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Mover em direção ao inimigo
        
        transform.position += direcao * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        {
            HealthComponent health = other.GetComponent<HealthComponent>();
            
            health?.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
