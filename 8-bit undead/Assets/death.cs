using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o nome do objeto é exatamente "BaseEnemy(Clone)"
        if (other.gameObject.name == "BaseEnemy(Clone)")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}