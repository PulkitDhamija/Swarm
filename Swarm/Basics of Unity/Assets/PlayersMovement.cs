using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called before the first frame update
    public float forwardForce = 2000f;
    public float sideWaysForce = 1000f;
    public float speed;

    // Update is called once per frame
    void FixedUpdate ()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if( Input.GetKey("d") )
        {
            rb.AddForce( sideWaysForce * Time.deltaTime, 0 , 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sideWaysForce * Time.deltaTime, 0, 0);
        }
    }
}
