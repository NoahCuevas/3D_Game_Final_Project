using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // prevent camera movement when dialogue is active
        if (dialogue_manager.Instance != null && dialogue_manager.Instance.isDialogueActive)
            return;

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player);
    }
}

