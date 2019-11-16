using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class FlameFlickering : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.LWRP.Light2D flameLight1;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D flameLight2;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D flameLight3;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D flameLight4;
    public UnityEngine.Experimental.Rendering.LWRP.Light2D flameLight5;
    public float flickeringFactor = 0.01f;
    private float flickeringTime = 1.0f;
    private int aleatoriedade;
    // Start is called before the first frame update
    void Start()
    {
        flameLight1.gameObject.SetActive(true); // ativa o objeto flame 1
        flameLight2.gameObject.SetActive(true); // ativa o objeto flame 2
        flameLight3.gameObject.SetActive(true); // ativa o objeto flame 3
        flameLight4.gameObject.SetActive(true); // ativa o objeto flame 4
        flameLight5.gameObject.SetActive(true); // ativa o objeto flame 5
        flameLight1.enabled = true; // liga flame 1
        flameLight2.enabled = false; // desliga flame 2
        flameLight3.enabled = false; // desliga flame 3
        flameLight4.enabled = false; // desliga flame 4
        flameLight5.enabled = false; // desliga flame 5
        
    }

    // Update is called once per frame
    void Update()
    {

        flickeringTime -= flickeringFactor;
        if(flickeringTime <= 0.0f)
        {
            aleatoriedade = Random.Range(0, 5);
            flickeringTime = 1.0f;
        }

        switch (aleatoriedade)
        {
            case 0:
                flameLight1.enabled = true; // liga flame 1
                flameLight2.enabled = false; // desliga flame 2
                flameLight3.enabled = false; // desliga flame 3
                flameLight4.enabled = false; // desliga flame 4
                flameLight5.enabled = false; // desliga flame 5
            break;
            case 1:
                flameLight1.enabled = false; // desliga flame 1
                flameLight2.enabled = true; // liga flame 2
                flameLight3.enabled = false; // desliga flame 3
                flameLight4.enabled = false; // desliga flame 4
                flameLight5.enabled = false; // desliga flame 5
            break;
            case 2:
                flameLight1.enabled = false; // desliga flame 1
                flameLight2.enabled = false; // desliga flame 2
                flameLight3.enabled = true; // liga flame 3
                flameLight4.enabled = false; // desliga flame 4
                flameLight5.enabled = false; // desliga flame 5
            break;
            case 3:
                flameLight1.enabled = false; // desliga flame 1
                flameLight2.enabled = false; // desliga flame 2
                flameLight3.enabled = false; // desliga flame 3
                flameLight4.enabled = true; // liga flame 4
                flameLight5.enabled = false; // desliga flame 5
            break;
            case 4:
                flameLight1.enabled = false; // desliga flame 1
                flameLight2.enabled = false; // desliga flame 2
                flameLight3.enabled = false; // desliga flame 3
                flameLight4.enabled = false; // desliga flame 4
                flameLight5.enabled = true; // liga flame 5
            break;
            default:
                flameLight1.enabled = true; // desliga flame 1
                flameLight2.enabled = false; // desliga flame 2
                flameLight3.enabled = false; // desliga flame 3
                flameLight4.enabled = false; // desliga flame 4
                flameLight5.enabled = false; // desliga flame 5
            break;
        }
    }
}
