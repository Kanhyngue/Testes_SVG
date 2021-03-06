﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class DayNightSystem : MonoBehaviour
{
    // Classes públicas
    public UnityEngine.Experimental.Rendering.Universal.Light2D globalLight; // Luz 2D GLOBAL

    public SpriteRenderer daySkybox, nightSkybox, twilightSkybox, morningSkybox; // Renderers dos Sprites das Skybox

    public GameObject caverna;
    public GameObject luzGlobal; // Luz 2D GLOBAL GameObject
    public GameObject luzCaverna;  // Luz 2D GLOBAL da Caverna GameObject

    [SerializeField]
    private GameObject aura;

    // Globais
    public static int dayPeriod; // 0 -> Manhã / 1 -> Dia / 2 -> Crepúsculo / 3 -> Noite

    // Variáveis Públicas - Editáveis no Editor
    public float dayTime = 300.0f; // Timer para saber o horário do dia

    // Classes privadas
    private Color mood; // Coloração da Luz 2D Global 
    // RGB - 126, 141, 217 -> Manhã / 255, 255, 255 -> Dia / 253, 176, 68 -> Crepúsculo / 91, 84, 209 -> Noite 

    // Variáveis Privadas
    private float r=1.0f, g=1.0f, b=1.0f; // Red, Green, Blue - Necessários para fazer a transição de cor da Luz 2D Global
    private float skyDayA=1.0f; // Alpha do Skybox DIA
    private float skyNightA=0.0f; // Alpha do Skybox NOITE
    private float skyTwilightA=0.0f; // Alpha do Skybox CREPÚSCULO
    private float skyMorningA=0.0f; // Alpha do Skybox MANHÃ
    private float lightIntensity; // Intensidade de Luz - Necessário para fazer a transição da intensidade da Luz 2D Global

    // Start is called before the first frame update
    void Start()
    {
        dayPeriod = 1;
        mood = new Color(r, g, b);
        globalLight.color = mood;
        lightIntensity = 1f;
        globalLight.intensity = lightIntensity;

        LightReset();
    }

    // verifica o horário e ajusta a luz de acordo com o horário
    private void LightReset()
    {
 
        // Parâmetros iniciais para mudança em Editor
        // Impede de bugar
        if(dayTime > 240.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 1;
            aura.SetActive(false);

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(1.0f, 1.0f, 1.0f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 1.0f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else if(dayTime <= 240.0f && dayTime > 225.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 2;

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(0.992157f, 0.690196f, 0.266667f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 0.8f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else if(dayTime <= 225.0f && dayTime > 165.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 2;

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(0.992157f, 0.690196f, 0.266667f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 0.8f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);

        }
        else if(dayTime <= 165.0f && dayTime > 150.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 3;
            aura.SetActive(true);

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(0.356863f, 0.329412f, 0.819608f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 0.6f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else if(dayTime <= 150.0f && dayTime > 90.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 3;
            aura.SetActive(true);

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(0.356863f, 0.329412f, 0.819608f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 0.6f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else if(dayTime <= 90.0f && dayTime > 75.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 0;
            aura.SetActive(false);

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(0.494118f, 0.552941f, 0.850980f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 0.85f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if(dayTime <= 75.0f && dayTime > 15.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 0;

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(0.494118f, 0.552941f, 0.850980f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 0.85f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if(dayTime <= 15.0f && dayTime > 0.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 1;

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(1.0f, 1.0f, 1.0f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 1.0f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
        else if(dayTime <= 0.0f)
        {
            // Parâmetro do Período do Dia
            dayPeriod = 1;

            // Parâmetros iniciais de coloração da Luz Global
            mood = new Color(1.0f, 1.0f, 1.0f); // Cor desse periodo do dia
            globalLight.color = mood; // Aplicando essas mudanças na cor da Luz Global

            // Parâmetros iniciais de intensidade da Luz Global
            globalLight.intensity = 1.0f; // Definindo intensidade da Luz Global

            // Parâmetros iniciais dos Skyboxes
            daySkybox.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(caverna.activeSelf)
        {
            luzGlobal.SetActive(false);
            luzCaverna.SetActive(true);
        }
        else{
            luzGlobal.SetActive(true);
            luzCaverna.SetActive(false);
            
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
        }
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
        lightIntensity -= 0.0005f;

        // Mudança do Skybox - Coloração muda para R-255 G-180 B-109 A-255
        // Sem necessidade de mudar a cor Red e o Alpha, então só se muda o Green e o Blue

        skyDayA = Mathf.Clamp(skyDayA, 0.0f, 1.0f);
        skyDayA -= 0.0075f;
        daySkybox.color = new Color(1.0f, 1.0f, 1.0f, skyDayA);
        skyTwilightA = Mathf.Clamp(skyTwilightA, 0, 1.0f);
        skyTwilightA += 0.0075f;
        twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, skyTwilightA);

    }

    // Transição entre o período Crepúsculo e a Noite
    public void TwilightToNight()
    {
        // Mudando o Período do Dia
        dayPeriod = 3; // É de noite
        aura.SetActive(true);

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
        lightIntensity -= 0.0005f;

        // Mudança do Skybox - A skybox Day some, e a skybox Night aparece
        // Sem necessidade de mudar as cores, somente os alphas
        skyTwilightA = Mathf.Clamp(skyTwilightA, 0.0f, 1.0f);
        skyTwilightA -= 0.0075f;
        twilightSkybox.color = new Color(1.0f, 1.0f, 1.0f, skyTwilightA);
        skyNightA = Mathf.Clamp(skyNightA, 0.0f, 1.0f);
        skyNightA += 0.0075f;
        nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, skyNightA);
    }

    // Transição entre o período Noite e a Manhã
    public void NightToEvening()
    {
        // Mudando o Período do Dia
        dayPeriod = 0; // É de manhã
        aura.SetActive(false);

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
        lightIntensity += 0.0005f;

        // Mudança do Skybox - A skybox Day aparece, e a skybox Night Some
        // Sem necessidade de mudar as cores, somente os alphas
        skyMorningA = Mathf.Clamp(skyMorningA, 0.0f, 1.0f);
        skyMorningA += 0.0075f;
        morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, skyMorningA);
        skyNightA = Mathf.Clamp(skyNightA, 0.0f, 1.0f);
        skyNightA -= 0.0075f;
        nightSkybox.color = new Color(1.0f, 1.0f, 1.0f, skyNightA);
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
        lightIntensity += 0.0005f;

        // Mudança do Skybox
        // Sem necessidade de mudar a cor Red, Green e o Alpha, então só se muda o Blue
        skyMorningA = Mathf.Clamp(1.0f, 1.0f, skyMorningA);
        skyMorningA -= 0.0075f;
        morningSkybox.color = new Color(1.0f, 1.0f, 1.0f, skyMorningA);
        skyDayA = Mathf.Clamp(1.0f,1.0f, skyDayA);
        skyDayA += 0.0075f;
        daySkybox.color = new Color(1.0f, 1.0f, 1.0f, skyDayA);
    }

   
}
