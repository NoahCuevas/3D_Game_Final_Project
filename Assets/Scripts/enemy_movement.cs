using UnityEngine;
using UnityEngine.AI;
public class enemy_movement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    private float fixedY;

    void Start()
    {
        targetPoint = 0;
        fixedY = transform.position.y;
    }

    void Update()
    {
        Vector3 targetPos = patrolPoints[targetPoint].position;
        targetPos.y = fixedY;

        Vector3 direction = targetPos - transform.position;
        if (direction != Vector3.zero)
        {
            transform.forward = direction.normalized; // Rotate to face direction of movement
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("waypoint"))
        {
            incrementTargetInt();
        }
    }

    void incrementTargetInt()
    {
        targetPoint++;   
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
