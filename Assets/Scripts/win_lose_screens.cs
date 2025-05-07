using UnityEngine;
using UnityEngine.SceneManagement;

public class win_lose_screens : MonoBehaviour
{
    // representing win and lose screens
    public GameObject win;
    public GameObject lose;

    public GameObject player;

    void Start() {
        win.SetActive(false);
        lose.SetActive(false);
    }

    // used for buttons
    public void MainMenu() {
        SceneManager.LoadScene("Title Menu");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void Quit() {
        Application.Quit();
    }

    // used for showing win or lose screen

    // called in update_player.cs (when player triggers game object with "End" tag)
    public void ShowWinScreen() {
        win.SetActive(true);
        Destroy(player);
    }

    // called in life_counter.cs (when all lives are lost)
    public void ShowLoseScreen() {
        lose.SetActive(true);
    }
}
