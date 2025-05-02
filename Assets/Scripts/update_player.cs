using UnityEngine;
using UnityEngine.UIElements;

public class update_player : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 lastCheckpointPosition;

    public GameObject checkpointTextbox;
    private void Start()
    {
        startPosition = transform.position;
        lastCheckpointPosition = startPosition;
        checkpointTextbox.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("bomb"))
        {
            Destroy(collision.gameObject);
            // sound_manager.Instance.PlaySound3D("Bomb", transform.position); // Plays random sound effect from group of clips
            life_counter.instance.subLife();
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            // sound_manager.Instance.PlaySound3D("Coin", transform.position);
            life_counter.instance.addPoints(); //Adds points to the counter once coin is collected
        }

        if (collision.gameObject.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
            // sound_manager.Instance.PlaySound3D("Coin", transform.position);
            life_counter.instance.addLife(); //Adds points to the counter once coin is collected
        }

        if (collision.gameObject.CompareTag("mace"))
        {
            // sound_manager.Instance.PlaySound3D("Mace", transform.position);
            life_counter.instance.subLife(); //Deducts from the life counter once player comes into contact with "Mace"
            Respawn();
        }

        if (collision.gameObject.CompareTag("enemy"))
        {
            // sound_manager.Instance.PlaySound3D("Bomb", transform.position); // Plays random sound effect from group of clips
            life_counter.instance.subLife();
        }

        if (collision.gameObject.CompareTag("pit"))
        {
            // sound_manager.Instance.PlaySound3D("Fall", transform.position);
            life_counter.instance.subLife();
            Respawn();
        }

        if (collision.gameObject.CompareTag("checkpoint"))
        {
            checkpoint_tracker checkpoint = collision.gameObject.GetComponent<checkpoint_tracker>();
            if (checkpoint != null && !checkpoint.activated)
            {
                checkpointTextbox.SetActive(true);
                checkpoint.activated = true;
                lastCheckpointPosition = collision.transform.position;
                //sound_manager.Instance.PlaySound3D("Checkpoint", transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            checkpointTextbox.SetActive(false); // hide checkpoint box when leaving checkpoint area
        }
    }

    void Respawn()
    {
        transform.position = lastCheckpointPosition;  // Move to start position
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;  // Disable CharacterController to reset it
            controller.enabled = true;   // Re-enable CharacterController after position reset
        }
    }

}
