using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformThrough : MonoBehaviour
{

    public BoxCollider2D boxCollider;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
            boxCollider.enabled = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
            boxCollider.enabled = true;
    }
}
