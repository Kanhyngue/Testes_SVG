using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class OcclusionCulling2D : MonoBehaviour
{

    public SpriteRenderer render;
    public UnityEngine.Experimental.Rendering.Universal.Light2D _lightSource;

    public void Start()
     {
        render.enabled = false;
        if (_lightSource != null)   
            {
                _lightSource.enabled = false;
            }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            render.enabled = true;
        }

        if (col.gameObject.CompareTag("OcclusionLight"))
        {
            if (_lightSource != null)   
            {
                _lightSource.enabled = true;
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Occlusion"))
        {
            render.enabled = true;
            if (_lightSource != null)
            {
                _lightSource.enabled = true;
            }
        }

        if (col.gameObject.CompareTag("OcclusionLight"))
        {
            if (_lightSource != null)
            {
                _lightSource.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Occlusion"))
        {
            render.enabled = false;
            if (_lightSource != null)
            {
                _lightSource.enabled = false;
            }
        }

        if(col.gameObject.CompareTag("OcclusionLight"))
        {
            if (_lightSource != null)
            {
                _lightSource.enabled = false;
            }
        }
    }
}
