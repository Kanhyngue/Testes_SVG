using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeHitBox : MonoBehaviour
{
    public static bool hit;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("PlayerHit"))
        {
            hit = true;
        }
    }
    
}
