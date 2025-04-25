using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelSelect : MonoBehaviour
{
    public void Play_Level_1() {
        SceneManager.LoadScene("Level_1"); 
    }

    public void Play_Level_2() {
        SceneManager.LoadScene("Level_2");
    }

    public void Play_Level_3() {
        SceneManager.LoadScene("Level_3");
    }

    public void Play_Level_4() {
        SceneManager.LoadScene("Level_4");
    }

    public void Play_Level_5() {
        SceneManager.LoadScene("Level_5");
    }
}
