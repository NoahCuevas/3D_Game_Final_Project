using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_movement : MonoBehaviour
{   
    public float speed;
    public float speed_rotation;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            {
                rigidbody.AddForce(transform.forward*speed);
            }

        gameObject.transform.Rotate(0,Input.GetAxis("Horizontal")*speed_rotation*Time.deltaTime,0);
    }
}
