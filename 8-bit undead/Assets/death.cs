using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para carregar cenas

public class death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o nome do objeto � exatamente "BaseEnemy(Clone)"
        if (other.gameObject.name == "BaseEnemy(Clone)")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}