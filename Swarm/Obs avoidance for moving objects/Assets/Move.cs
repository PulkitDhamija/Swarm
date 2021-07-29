using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    public float forwardForce = 2000f;
    public float sideWaysForce = 1000f;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (Input.GetKey("d"))
        {
            rb.AddForce(0, 0, sideWaysForce * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(0, 0, -sideWaysForce * Time.deltaTime);
        }
    }
}