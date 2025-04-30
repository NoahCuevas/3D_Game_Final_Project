using UnityEngine;

public class update_player : MonoBehaviour
{
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
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
    }

    void Respawn()
    {
        transform.position = startPosition;  // Move to start position
        CharacterController controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false;  // Disable CharacterController to reset it
            controller.enabled = true;   // Re-enable CharacterController after position reset
        }
    }

}
