using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeHitBox : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("PlayerHit") && !BossMelee._hit)
        {
            BossMelee._hit = true;
        }
    }
    
}
