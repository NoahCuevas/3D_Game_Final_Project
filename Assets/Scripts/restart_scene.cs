using UnityEngine;
using UnityEngine.SceneManagement;

public class restart_scene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
