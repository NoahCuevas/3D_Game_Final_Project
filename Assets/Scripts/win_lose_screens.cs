using UnityEngine;
using UnityEngine.SceneManagement;

public class win_lose_screens : MonoBehaviour
{
    // representing win and lose screens
    public GameObject win;
    public GameObject lose;

    public GameObject player;

    public GameObject audio_manager;

    void Start() {
        win.SetActive(false);
        lose.SetActive(false);
    }

    // used for buttons
    public void MainMenu() {
        // // destroy audio manager to stop background music + prevent 2 audio listeners
        // Destroy(audio_manager);
        
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

        // block player movement and camera movement
        player.GetComponent<character_translation>().enabled = false;
        player.GetComponent<camera_manager>().enabled = false;

        // unlock cursor to allow player to click buttons
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;                 
    }

    // called in life_counter.cs (when all lives are lost)
    public void ShowLoseScreen() {
        lose.SetActive(true);
        
        // block player movement and camera movement
        player.GetComponent<character_translation>().enabled = false;
        player.GetComponent<camera_manager>().enabled = false;

        // unlock cursor to allow player to click buttons
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;                 
    }
}
