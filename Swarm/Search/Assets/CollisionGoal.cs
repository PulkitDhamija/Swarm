using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGoal : MonoBehaviour
{
    public Rigidbody rb1, rb2, rb3, rb4, rb5, rb6;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Found it");
            GameObject varGameObject = GameObject.Find("Player");
            GameObject varGameObject1 = GameObject.Find("Player (1)");
            GameObject varGameObject2 = GameObject.Find("Player (2)");
            GameObject varGameObject3 = GameObject.Find("Player (3)");
            GameObject varGameObject4 = GameObject.Find("Player (4)");
            GameObject varGameObject5 = GameObject.Find("Player (5)");
            GameObject varGameObject6 = GameObject.Find("PotentialF");

            varGameObject.GetComponent<BB>().enabled = false;
            varGameObject1.GetComponent<BB1>().enabled = false;
            varGameObject2.GetComponent<BB2>().enabled = false;
            varGameObject3.GetComponent<BB3>().enabled = false;
            varGameObject4.GetComponent<BB4>().enabled = false;
            varGameObject5.GetComponent<BB4>().enabled = false;
            varGameObject6.GetComponent<Potential>().enabled = false;

            rb1.constraints = RigidbodyConstraints.FreezeAll;
            rb2.constraints = RigidbodyConstraints.FreezeAll;
            rb3.constraints = RigidbodyConstraints.FreezeAll;
            rb4.constraints = RigidbodyConstraints.FreezeAll;
            rb5.constraints = RigidbodyConstraints.FreezeAll;
            rb6.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
