using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Esse método pode ser chamado pelo botão no Inspector
    public void LoadScene2()
    {
        SceneManager.LoadScene("Scene2");
    }
}
