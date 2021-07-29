using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSO : MonoBehaviour
{
    public Transform rb1, rb2, rb3, rb4, rb5, rb6, goal;
    Vector3 p1best = Vector3.positiveInfinity, p2best = Vector3.positiveInfinity, p3best = Vector3.positiveInfinity,  p4best = Vector3.positiveInfinity, p5best = Vector3.positiveInfinity, p6best = Vector3.positiveInfinity;
    float p1best_val = 1000f, p2best_val = 1000f, p3best_val = 1000f, p4best_val = 1000f, p5best_val = 1000f, p6best_val = 1000f;
    float w = 0.5f, c1 = 1f, c2 = 1f;
    float alpha = 0.009f, beta = 0.5f;
    Vector3 v1 = Vector3.zero, v2 = Vector3.zero, v3 = Vector3.zero, v4 = Vector3.zero, v5 = Vector3.zero, v6 = Vector3.zero;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 g = goal.position;
        Vector3 d1g = goal.position - rb1.position;
        Vector3 d2g = goal.position - rb2.position;
        Vector3 d3g = goal.position - rb3.position;
        Vector3 d4g = goal.position - rb4.position;
        Vector3 d5g = goal.position - rb5.position;
        Vector3 d6g = goal.position - rb6.position;

        Vector3 r11 = rb2.position - rb1.position;
        Vector3 r12 = rb3.position - rb1.position;
        Vector3 r13 = rb4.position - rb1.position;
        Vector3 r14 = rb5.position - rb1.position;
        Vector3 r15 = rb6.position - rb1.position;

        Vector3 r21 = rb1.position - rb2.position;
        Vector3 r22 = rb3.position - rb2.position;
        Vector3 r23 = rb4.position - rb2.position;
        Vector3 r24 = rb5.position - rb2.position;
        Vector3 r25 = rb6.position - rb2.position;

        Vector3 r31 = rb1.position - rb3.position;
        Vector3 r32 = rb2.position - rb3.position;
        Vector3 r33 = rb4.position - rb3.position;
        Vector3 r34 = rb5.position - rb3.position;
        Vector3 r35 = rb6.position - rb3.position;

        Vector3 r41 = rb1.position - rb4.position;
        Vector3 r42 = rb2.position - rb4.position;
        Vector3 r43 = rb3.position - rb4.position;
        Vector3 r44 = rb3.position - rb4.position;
        Vector3 r45 = rb6.position - rb4.position;

        Vector3 r51 = rb1.position - rb5.position;
        Vector3 r52 = rb2.position - rb5.position;
        Vector3 r53 = rb3.position - rb5.position;
        Vector3 r54 = rb4.position - rb5.position;
        Vector3 r55 = rb6.position - rb5.position;

        Vector3 r61 = rb1.position - rb6.position;
        Vector3 r62 = rb2.position - rb6.position;
        Vector3 r63 = rb3.position - rb6.position;
        Vector3 r64 = rb4.position - rb6.position;
        Vector3 r65 = rb5.position - rb6.position;

        Vector3 f1net = repulsion(r11, r12, r13, r14, r15);
        Vector3 f2net = repulsion(r21, r22, r23, r24, r25);
        Vector3 f3net = repulsion(r31, r32, r33, r34, r35);
        Vector3 f4net = repulsion(r41, r42, r43, r44, r45);
        Vector3 f5net = repulsion(r51, r52, r53, r54, r55);
        Vector3 f6net = repulsion(r61, r62, r63, r64, r65);

        if (d1g.magnitude > 7.5 && d2g.magnitude > 7.5 && d3g.magnitude > 7.5 && d4g.magnitude > 7.5 && d5g.magnitude > 7.5 && d6g.magnitude > 7.5)
        {
            p1best = find_pbest(d1g, p1best, p1best_val, g); p1best_val = find_pbestval(d1g, p1best_val);
            p2best = find_pbest(d2g, p2best, p2best_val, g); p2best_val = find_pbestval(d2g, p2best_val);
            p3best = find_pbest(d3g, p1best, p3best_val, g); p3best_val = find_pbestval(d3g, p3best_val);
            p4best = find_pbest(d4g, p1best, p4best_val, g); p4best_val = find_pbestval(d4g, p4best_val);
            p5best = find_pbest(d5g, p1best, p5best_val, g); p5best_val = find_pbestval(d5g, p5best_val);
            p6best = find_pbest(d6g, p1best, p6best_val, g); p6best_val = find_pbestval(d6g, p6best_val);
            Vector3 dgbest = find_dgbest(d1g, d2g, d3g, d4g, d5g, d6g, g);

            v1 = w * v1 + c1 * Random.value * (p1best - rb1.position) + c2 * Random.value * (dgbest - rb1.position);
            rb1.position += alpha * v1 + beta * f1net;

            v2 = w * v2 + c1 * Random.value * (p2best - rb2.position) + c2 * Random.value * (dgbest - rb2.position);
            rb2.position += alpha * v2 + beta * f2net;

            v3 = w * v3 + c1 * Random.value * (p3best - rb3.position) + c2 * Random.value * (dgbest - rb3.position);
            rb3.position += alpha * v3 + beta * f3net;

            v4 = w * v4 + c1 * Random.value * (p4best - rb4.position) + c2 * Random.value * (dgbest - rb4.position);
            rb4.position += alpha * v4 + beta * f4net;

            v5 = w * v5 + c1 * Random.value * (p5best - rb5.position) + c2 * Random.value * (dgbest - rb5.position);
            rb5.position += alpha * v5 + beta * f5net;

            v6 = w * v6 + c1 * Random.value * (p6best - rb6.position) + c2 * Random.value * (dgbest - rb6.position);
            rb6.position += alpha * v6 + beta * f6net;
        }
        else
        {
            Debug.Log("Found it");
        }
        static float find_pbestval(Vector3 d, float pbest_val)
        {
            float temp;
            if (d.magnitude < pbest_val)
            {
                temp = d.magnitude;
            }
            else temp = pbest_val;
            return temp;
        }
        static Vector3 find_pbest(Vector3 d, Vector3 d1, float pbest_val, Vector3 g)
        {
            Vector3 temp;
            if (d.magnitude < pbest_val)
            {
                temp = g - d;
            }
            else temp = d1;
            return temp;
        }
        static Vector3 find_dgbest(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5, Vector3 d6, Vector3 g)
        {
            Vector3 d = Vector3.zero;
            float temp = Mathf.Min(d1.magnitude, d2.magnitude, d3.magnitude, d4.magnitude, d5.magnitude, d6.magnitude);
            if (d1.magnitude == temp)
            { d = g - d1; }
            else if (d2.magnitude == temp)
            { d = g - d2; }
            else if (d3.magnitude == temp)
            { d = g - d3; }
            else if (d4.magnitude == temp)
            { d = g - d4; }
            else if (d5.magnitude == temp)
            { d = g - d5; }
            else if (d6.magnitude == temp)
            { d = g - d6; }
            return d;
        }
        static Vector3 repulsion(Vector3 d1, Vector3 d2, Vector3 d3, Vector3 d4, Vector3 d5)
        {
            float a0 = 50f, k = 10000f;
            Vector3 fnet, f1, f2, f3, f4, f5;
            if (d1.magnitude <= a0)
                f1 = k * (1 / d1.sqrMagnitude) * (1 / d1.magnitude - 1 / a0) * (-d1.normalized);
            else f1 = Vector3.zero;
            if (d2.magnitude <= a0)
                f2 = k * (1 / d2.sqrMagnitude) * (1 / d2.magnitude - 1 / a0) * (-d2.normalized);
            else f2 = Vector3.zero;
            if (d3.magnitude <= a0)
                f3 = k * (1 / d3.sqrMagnitude) * (1 / d3.magnitude - 1 / a0) * (-d3.normalized);
            else f3 = Vector3.zero;
            if (d4.magnitude <= a0)
                f4 = k * (1 / d4.sqrMagnitude) * (1 / d4.magnitude - 1 / a0) * (-d4.normalized);
            else f4 = Vector3.zero;
            if (d5.magnitude <= a0)
                f5 = k * (1 / d5.sqrMagnitude) * (1 / d5.magnitude - 1 / a0) * (-d5.normalized);
            else f5 = Vector3.zero;
            fnet = f1 + f2 + f3 + f4 + f5;
            return fnet;
        }
    }
}
