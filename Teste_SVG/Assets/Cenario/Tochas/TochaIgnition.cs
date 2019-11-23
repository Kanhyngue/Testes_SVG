using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class TochaIgnition : MonoBehaviour
{
    private Animator anim;
    private UnityEngine.Experimental.Rendering.LWRP.Light2D tochaLight;

    void Start()
    {
        anim = GetComponent<Animator>();
        tochaLight = GetComponentInChildren<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Tiro") && gameObject.CompareTag("TochaApagada"))
        {
            anim.SetBool("Aceso", true);
            tochaLight.enabled = true;
            gameObject.tag = "TochaAcesa";
        }
    }
}
