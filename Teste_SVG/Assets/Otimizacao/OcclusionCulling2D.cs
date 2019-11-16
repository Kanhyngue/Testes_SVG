using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionCulling2D : MonoBehaviour
{

    public SpriteRenderer render;

    void Start()
    {
        render.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            render.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            render.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Occlusion"))
        {
            render.enabled = false;
        }
    }
}
