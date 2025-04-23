using UnityEngine;
using System.Collections.Generic;

public class ShootComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public List<GameObject> inimigosNoRange = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inimigosNoRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            inimigosNoRange.Remove(other.gameObject);
        }
    }

    void Atirar()
    {
        GameObject alvo = inimigosNoRange[0];

        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.target = alvo;
    }

    void Update()
    {
        if (inimigosNoRange.Count > 0 && fireCountdown <= 0f)
        {
            Atirar();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
}
