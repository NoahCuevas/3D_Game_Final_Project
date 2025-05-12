using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_scene : MonoBehaviour
{
    void Update()
    {
        // add if we want player to be able to restart the game manually
        // if (Input.GetKey("r"))
        // {
        //     Restart();
        // }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
