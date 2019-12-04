using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicaoMenu : MonoBehaviour
{
    private bool active;
    private float alphaChannel = 0.0f;
    [SerializeField]
    private float speedFade = 0.1f;
    private SpriteRenderer thisSprite;

    private void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    public void TransicaoAceita()
    {
        active = true;
    }

    void FixedUpdate()
    {
        if (active)
        {
                alphaChannel += speedFade;
                thisSprite.color = new Color(0f, 0f, 0f, Mathf.Clamp(alphaChannel, 0f, 1f));
        }
    }
}
