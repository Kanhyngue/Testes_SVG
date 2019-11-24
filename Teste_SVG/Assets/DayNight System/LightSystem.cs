using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightSystem : MonoBehaviour
{
    public GameObject caverna;
    private UnityEngine.Experimental.Rendering.LWRP.Light2D lightGeral;

    void Start()
    {
        lightGeral = GetComponent<UnityEngine.Experimental.Rendering.LWRP.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(caverna.activeSelf)
        {
            lightGeral.intensity = 0.0f;
        }
        else
        {
            lightGeral.intensity = 1.0f;
        }
    }
}
