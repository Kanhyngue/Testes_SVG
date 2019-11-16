using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class DayNightSystem : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.LWRP.Light2D globalLight;
    public float dayTime = 300.0f;

    public SpriteRenderer daySkybox, nightSkybox;

    private int dayPeriod; // 0 -> Manhã / 1 -> Dia / 2 -> Crepúsculo / 3 -> Noite
    private Color mood; // RGB - 126, 141, 217 -> Manhã / 255, 255, 255 -> Dia / 253, 176, 68 -> Crepúsculo / 91, 84, 209 -> Noite 
    private float r=1.0f, g=1.0f, b=1.0f;
    private float skyDayR=1.0f, skyDayG=1.0f, skyDayB=1.0f, skyDayA=1.0f;
    private float skyNightR=1.0f, skyNightG=1.0f, skyNightB=1.0f, skyNightA=0.0f;
    private float lightIntensity;

    // Start is called before the first frame update
    void Start()
    {
        dayPeriod = 1;
        mood = new Color(r, g, b);
        globalLight.color = mood;
        lightIntensity = 1f;
        globalLight.intensity = lightIntensity;

        // Parâmetros iniciais para mudança em Editor
        // Impede de bugar
        if(dayTime > 240.0f)
        {
            r=1.0f;
            g=1.0f;
            b=1.0f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
        else if(dayTime <= 240.0f && dayTime > 225.0f)
        {
            r=1.0f;
            g=1.0f;
            b=1.0f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
        else if(dayTime <= 225.0f && dayTime > 165.0f)
        {
            r=0.992157f;
            g=0.690196f;
            b=0.266667f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
        else if(dayTime <= 165.0f && dayTime > 150.0f)
        {
            r=0.992157f;
            g=0.690196f;
            b=0.266667f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
        else if(dayTime <= 150.0f && dayTime > 90.0f)
        {
            r=0.356863f;
            g=0.329412f;
            b=0.819608f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=0.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=1.0f;
        }
        else if(dayTime <= 90.0f && dayTime > 75.0f)
        {
            r=0.356863f;
            g=0.329412f;
            b=0.819608f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=0.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=1.0f;
        }
        else if(dayTime <= 75.0f && dayTime > 15.0f)
        {
            r=0.494118f;
            g=0.552941f;
            b=0.850980f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
        else if(dayTime <= 15.0f && dayTime > 0.0f)
        {
            r=0.494118f;
            g=0.552941f;
            b=0.850980f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
        else if(dayTime <= 0.0f)
        {
            r=1.0f;
            g=1.0f;
            b=1.0f;
            skyDayR=1.0f;
            skyDayG=1.0f;
            skyDayB=1.0f;
            skyDayA=1.0f;
            skyNightR=1.0f;
            skyNightG=1.0f;
            skyNightB=1.0f;
            skyNightA=0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dayTime -= Time.deltaTime;

        if(dayTime <= 240.0f && dayTime > 225.0f)
        {
            DayToTwilight();
        }
        else if(dayTime <= 165.0f && dayTime > 150.0f)
        {
            TwilightToNight();
        }
        else if(dayTime <= 90.0f && dayTime > 75.0f)
        {
            NightToEvening();
        }
        else if(dayTime <= 15.0f && dayTime > 0.0f)
        {
            EveningToDay();
        }
        else if(dayTime <= 0.0f)
        {
            TimerReset();
        }

        //Debug.Log(dayTime);
    }

    // Reseta o timer de 5 minutos
    private void TimerReset()
    {
        dayTime = 300.0f;
    }

    // Transição entre o período Dia e o Crespúsculo
    public void DayToTwilight()
    {
        // Mudando o Período do Dia
        dayPeriod = 2; // É de tarde

        // Mudando coloração
        r = Mathf.Clamp(r, 0.992157f, 1.0f);
        r -= 0.001f;
        g = Mathf.Clamp(g, 0.690196f, 1.0f);
        g -= 0.001f;
        b = Mathf.Clamp(b, 0.266667f, 1.0f);
        b -= 0.001f;
        mood = new Color(r, g, b);
        globalLight.color = mood;

        // Mudando intensidade do Brilho
        globalLight.intensity = Mathf.Clamp(lightIntensity, 0.8f, 1.0f);
        lightIntensity -= 0.00035f;

        // Mudança do Skybox - Coloração muda para R-255 G-180 B-109 A-255
        // Sem necessidade de mudar a cor Red e o Alpha, então só se muda o Green e o Blue
        skyDayG = Mathf.Clamp(skyDayG, 0.705882f, 1.0f);
        skyDayG -= 0.001f;
        skyDayB = Mathf.Clamp(skyDayB, 0.427451f, 1.0f);
        skyDayB -= 0.001f;
        daySkybox.color = new Color(skyDayR, skyDayG, skyDayB, skyDayA);
    }

    // Transição entre o período Crepúsculo e a Noite
    public void TwilightToNight()
    {
        // Mudando o Período do Dia
        dayPeriod = 3; // É de noite

        // Mudando coloração
        r = Mathf.Clamp(r, 0.356863f, 0.992157f);
        r -= 0.001f;
        g = Mathf.Clamp(g, 0.329412f, 0.690196f);
        g -= 0.001f;
        b = Mathf.Clamp(b, 0.266667f, 0.819608f);
        b += 0.001f;
        mood = new Color(r, g, b);
        globalLight.color = mood;

        // Mudando intensidade do Brilho
        globalLight.intensity = Mathf.Clamp(lightIntensity, 0.6f, 0.8f);
        lightIntensity -= 0.00035f;

        // Mudança do Skybox - A skybox Day some, e a skybox Night aparece
        // Sem necessidade de mudar as cores, somente os alphas
        skyDayA = Mathf.Clamp(skyDayA, 0.0f, 1.0f);
        skyDayA -= 0.0025f;
        daySkybox.color = new Color(skyDayR, skyDayG, skyDayB, skyDayA);
        skyNightA = Mathf.Clamp(skyNightA, 0.0f, 1.0f);
        skyNightA += 0.0025f;
        nightSkybox.color = new Color(skyNightR, skyNightG, skyNightB, skyNightA);
    }

    // Transição entre o período Noite e a Manhã
    public void NightToEvening()
    {
        // Mudando o Período do Dia
        dayPeriod = 0; // É de manhã

        // Mudando coloração
        r = Mathf.Clamp(r, 0.356863f, 0.494118f);
        r += 0.001f;
        g = Mathf.Clamp(g, 0.329412f, 0.552941f);
        g += 0.001f;
        b = Mathf.Clamp(b, 0.819608f, 0.850980f);
        b += 0.001f;
        mood = new Color(r, g, b);
        globalLight.color = mood;

        // Mudando intensidade do Brilho
        globalLight.intensity = Mathf.Clamp(lightIntensity, 0.6f, 0.85f);
        lightIntensity += 0.00035f;

        // Mudança do Skybox - A skybox Day aparece, e a skybox Night Some
        // Sem necessidade de mudar as cores, somente os alphas
        skyDayR = 1.0f;
        skyDayG = 1.0f;
        skyDayB = 0.541176f;
        skyDayA = Mathf.Clamp(skyDayA, 0.0f, 1.0f);
        skyDayA += 0.0025f;
        daySkybox.color = new Color(skyDayR, skyDayG, skyDayB, skyDayA);
        skyNightA = Mathf.Clamp(skyNightA, 0.0f, 1.0f);
        skyNightA -= 0.0025f;
        nightSkybox.color = new Color(skyNightR, skyNightG, skyNightB, skyNightA);
    }

    // Transição entre o período Manhã e o Dia
    public void EveningToDay()
    {
        // Mudando o Período do Dia
        dayPeriod = 1; // É de dia

        // Mudando coloração
        r = Mathf.Clamp(r, 0.494118f, 1.0f);
        r += 0.001f;
        g = Mathf.Clamp(g, 0.552941f, 1.0f);
        g += 0.001f;
        b = Mathf.Clamp(b, 0.850980f, 1.0f);
        b += 0.001f;
        mood = new Color(r, g, b);
        globalLight.color = mood;

        // Mudando intensidade do Brilho
        globalLight.intensity = Mathf.Clamp(lightIntensity, 0.85f, 1.0f);
        lightIntensity += 0.00035f;

        // Mudança do Skybox
        // Sem necessidade de mudar a cor Red, Green e o Alpha, então só se muda o Blue
        skyDayB = Mathf.Clamp(skyDayB, 0.541176f, 1.0f);
        skyDayB += 0.001f;
        daySkybox.color = new Color(skyDayR, skyDayG, skyDayB, skyDayA);
    }

   
}
