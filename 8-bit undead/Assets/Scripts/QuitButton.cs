using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    public void QuitGame()
    {
        // Encerra o jogo
        Application.Quit();

        // Para testes no editor
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
