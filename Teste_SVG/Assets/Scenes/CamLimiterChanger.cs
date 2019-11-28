using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLimiterChanger : MonoBehaviour
{
    public GameObject camLimiter1, camLimiter2;

    private bool scriptActive; // Se o propósito deste script for alcançado então ele não precisa ser mais rodado
    // Dessa forma previne o Memory Leaking

    void Start()
    {
        scriptActive = true; // Ele começa já verdadeiro mas é em sua execução que definirá se ele estará falso ou não
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(scriptActive)
        {
            // SE o jogador coletar o poder da neblina
            if(DataSystem.fogPower)
            {
                camLimiter1.SetActive(true); // Muda o limiter da camera para 1
                camLimiter2.SetActive(false); // Muda o limiter da camera para 2
                scriptActive = false; // Propósito alcançado, script é inutilizado.
            }
        }
        
    }
}
