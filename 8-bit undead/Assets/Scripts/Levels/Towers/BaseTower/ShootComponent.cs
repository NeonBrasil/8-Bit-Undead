using UnityEngine;
using System.Collections.Generic;

public class ShootComponent : MonoBehaviour
{
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

    void Update()
    {
        if (inimigosNoRange.Count > 0)
        {
            // Atira no primeiro inimigo
            Debug.Log("Torre atira em: " + inimigosNoRange[0].name);
        }
    }
}
