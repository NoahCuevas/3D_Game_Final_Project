using UnityEngine;
using UnityEngine.AI;

public class thwomp_movement : MonoBehaviour
{
    public Transform[] waypoints; // Assign 2 points: top and bottom
    public float speed = 3f;
    private int currentTarget = 0;

    void Update()
    {
        if (waypoints.Length < 2) return;

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTarget].position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("waypoint"))
        {
            // Switch to the other waypoint
            currentTarget = (currentTarget + 1) % waypoints.Length;
        }
    }
}