using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolhasDesaparecer : MonoBehaviour
{
    private bool active = false;
    private bool entered = false;
    private float alphaChannel = 1.0f;

    public float speedFade = 0.1f;

    public SpriteRenderer folhas;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            alphaChannel = 1f;
            entered = true;
            active = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            alphaChannel = 0f;
            entered = false;
        }
    }

    void FixedUpdate()
    {
        if(active)
        {
            if(entered)
            {
                alphaChannel -= speedFade;
                folhas.color = new Color(1f, 1f, 1f, Mathf.Clamp(alphaChannel, 0f, 1f));
            }
            else
            {
                alphaChannel += speedFade;
                folhas.color = new Color(1f, 1f, 1f, Mathf.Clamp(alphaChannel, 0f, 1f));
            }

            if(alphaChannel >= 1.0f)
            {
                active = false;
            }
        }
    }
}
