using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersCollision : MonoBehaviour
{
    public PlayersMovement movement;
    void OnCollisionEnter ( Collision collisonInfo)
    {
        if(collisonInfo.collider.tag == "Obstacel")
        {
            movement.enabled = false;
        }
       
    }
    
}
