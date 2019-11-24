using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class TochaIgnition : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem fireParticle, smokeParticle;
    private UnityEngine.Experimental.Rendering.LWRP.Light2D tochaLight;

    void Start()
    {
        anim = GetComponent<Animator>();
        tochaLight = GetComponentInChildren<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
        smokeParticle.Stop();
        fireParticle.Stop();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Tiro") && gameObject.CompareTag("TochaApagada"))
        {
            anim.SetBool("Aceso", true);
            fireParticle.Play();
            tochaLight.enabled = true;
            gameObject.tag = "TochaAcesa";
        }
    }
}
