using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("Intro Cutscene");
    }

    public void Quit() {
        Application.Quit();
    }
}
