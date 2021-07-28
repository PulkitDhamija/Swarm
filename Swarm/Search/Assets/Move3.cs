using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour
{
    float timecounter = 0, l, t, b, speed, x, y, z, c;

    void Start()
    {
        speed = 1; l = 175; b = 175;
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

