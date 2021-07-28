using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    float timecounter = 0, l, t, b, speed, x, y, z, c;

    void Start()
    {
        speed = 3;l = 4;b = 4;
    }


    void Update()
    {
        timecounter = timecounter + Time.deltaTime * speed;
    }
    void FixedUpdate()
    {
        x = Mathf.Cos(timecounter)*b;
        y = 0;
        z = Mathf.Cos(timecounter) * Mathf.Sin(timecounter)*l;
        transform.position = new Vector3(x, y, z);
    }
}


