using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class FlameHour : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.LWRP.Light2D _lightSource;
    public ParticleSystem fireParticle, smokeParticle;

    public bool programacaoHoraria;

    private int periodo;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if(programacaoHoraria)
        {
            periodo = DayNightSystem.dayPeriod;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(programacaoHoraria)
        {
            periodo = DayNightSystem.dayPeriod;
            switch (periodo)
            {
                case 0:
                    anim.SetBool("Aceso", false);
                    _lightSource.enabled = false;
                    fireParticle.Stop();
                    smokeParticle.Play();
                break;
                case 1:
                    anim.SetBool("Aceso", false);
                    _lightSource.enabled = false;
                    fireParticle.Stop();
                    smokeParticle.Stop();
                break;
                case 2:
                    anim.SetBool("Aceso", true);
                    _lightSource.enabled = true;
                    fireParticle.Play();
                    smokeParticle.Stop();
                break;
                case 3:
                    anim.SetBool("Aceso", true);
                    _lightSource.enabled = true;
                    fireParticle.Play();
                    smokeParticle.Stop();
                break;
                default:
                    anim.SetBool("Aceso", false);
                    _lightSource.enabled = false;
                    fireParticle.Stop();
                    smokeParticle.Stop();
                break;
            }
        }
    }
}
