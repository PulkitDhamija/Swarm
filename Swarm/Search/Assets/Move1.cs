using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    float timecounter = 0, l, b, speed, x, y, z;

    void Start()
    {
        speed = 1f; l = 120; b = 120;
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
