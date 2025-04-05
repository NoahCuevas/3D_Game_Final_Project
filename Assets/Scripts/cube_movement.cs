using UnityEngine;

public class cube_movement : MonoBehaviour
{
    public float speed;
    public float speed_rotation;
    private Rigidbody rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(transform.forward * speed);
        }
        gameObject.transform.Rotate(0, Input.GetAxis("Horizontal") * speed_rotation * Time.deltaTime, 0);
    }
}
