using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float timecounter = 0, l, b, speed, x, y, z;

    void Start()
    {
        speed =(float)1.0; l = 100; b = 100;
    }


    void Update()
    {
        timecounter = timecounter + Time.deltaTime * speed;
    }
    void FixedUpdate()
    {
        x = Mathf.Cos(timecounter) * b;
        y = 7;
        z = Mathf.Sin(timecounter) * l;
        transform.position = new Vector3(x, y, z);
    }
}
