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
