﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    // Variáveis AudioSource da Ambientação
    public AudioSource hubAmbient, cerradoAmbient, florestaAmbient, cavernaAmbient;
    // Variáveis AudioSource de música
    public AudioSource hubSource, cerradoSource, florestaSource, cavernaSource;
    // Cenários
    public GameObject hub, cerrado, floresta, caverna;
    // Duração do FadeOff
    public float fadeOffDuration;
    // Timer do fade off
    private float currentTime = 0f;
    // Variável da cena atual ativada
    private int cena;
    // Booleana de ativação da troca de música
    private bool change = false;
    private bool changeToChange = false;

    // ----- Método Update ----- //
    void Update()
    {
        VerificarCena(); // Método para verificar a cena atual ativada
        if(change)
        {
            change = false;
        }
    }

    void Start()
    {
        cena = 0;
        if(hub.activeSelf)
        {
            hubSource.Play();
            hubAmbient.Play();
        }
    }

    // ----- Método para verificar a cena atual ativada ----- //
    void VerificarCena()
    {
        if(hub.activeSelf && cena != 0)
        {
            if(change)
            {
                cena = 0;
                AtribuirSource(cena);

                hubSource.volume = 1f;
                hubAmbient.volume = 1f;
            }
            else
            {
                if(cena == 1)
                {
                    FadeMusic(cena);
                }
                else if(cena == 2)
                {
                    FadeMusic(cena);
                }
                else if(cena == 3)
                {
                    FadeMusic(cena);
                }     
            }
        }
        else if(cerrado.activeSelf && cena != 1)
        {
            if(change)
            {
                cena = 1;
                AtribuirSource(cena);

                cerradoSource.volume = 1f;
                cerradoAmbient.volume = 1f;
            }
            else
            {
                if(cena == 0)
                {
                    FadeMusic(cena);
                }
                else if(cena == 2)
                {
                    FadeMusic(cena);
                }
                else if(cena == 3)
                {
                    FadeMusic(cena);
                }
            }
        }
        else if(floresta.activeSelf && cena != 2)
        {
            if(change)
            {
                cena = 2;
                AtribuirSource(cena);

                florestaSource.volume = 1f;
                florestaAmbient.volume = 1f;
            }
            else
            {
                if(cena == 0)
                {
                    FadeMusic(cena);
                }
                else if(cena == 1)
                {
                    FadeMusic(cena);
                }
                else if(cena == 3)
                {
                    FadeMusic(cena);
                }
            }
        }
        else if(caverna.activeSelf && cena != 3)
        {
            if(change)
            {
                cena = 3;
                AtribuirSource(cena);

                cavernaSource.volume = 1f;
                cavernaAmbient.volume = 1f;
            }
            else
            {
                if(cena == 0)
                {
                    FadeMusic(cena);
                }
                else if(cena == 1)
                {
                    FadeMusic(cena);
                }
                else if(cena == 2)
                {
                    FadeMusic(cena);
                }
            }
        }
    }

    // ----- Método para realizar o Fade Off da Música da cena que está sendo desativada ----- //
    public void FadeMusic(int _cena)
    {   
        switch(_cena)
        {
            case 0:
                if(currentTime < fadeOffDuration)
                {
                    currentTime += Time.deltaTime;
                    hubSource.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                    hubAmbient.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                }
                else
                {
                    StartCoroutine(Delay());
                }
            break;
            case 1:
                if(currentTime < fadeOffDuration)
                {
                    currentTime += Time.deltaTime;
                    cerradoSource.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                    cerradoAmbient.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                }
                else
                {
                    StartCoroutine(Delay());
                }
            break;
            case 2:
                if(currentTime < fadeOffDuration)
                {
                    currentTime += Time.deltaTime;
                    florestaSource.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                    florestaAmbient.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                }
                else
                {
                    StartCoroutine(Delay());
                }
            break;
            case 3:
                if(currentTime < fadeOffDuration)
                {
                    currentTime += Time.deltaTime;
                    cavernaSource.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                    cavernaAmbient.volume = Mathf.Lerp(1f, 0f, currentTime / fadeOffDuration);
                }
                else
                {
                    StartCoroutine(Delay());
                }
            break;
            default:
                // não faz porra nenhuma.
            break;
        }
    }

    // ---- Método para trocar a Música e Ambientação ----- //
    public void AtribuirSource(int _cena)
    {
        switch(_cena)
        {
            case 0:
                hubSource.Play();
                cerradoSource.Stop();
                florestaSource.Stop();
                cavernaSource.Stop();
                
                hubAmbient.Play();
                cerradoAmbient.Stop();
                florestaAmbient.Stop();
                cavernaSource.Stop();

                currentTime = 0f;
            break;
            case 1:
                cerradoSource.Play();
                hubSource.Stop();
                florestaSource.Stop();
                cavernaSource.Stop();

                hubAmbient.Stop();
                cerradoAmbient.Play();
                florestaAmbient.Stop();
                cavernaSource.Stop();

                currentTime = 0f;
            break;
            case 2:
                florestaSource.Play();
                cerradoSource.Stop();
                hubSource.Stop();
                cavernaSource.Stop();

                hubAmbient.Stop();
                cerradoAmbient.Stop();
                florestaAmbient.Play();
                cavernaSource.Stop();

                currentTime = 0f;
            break;
            case 3:
                cavernaSource.Play();
                cerradoSource.Stop();
                florestaSource.Stop();
                hubSource.Stop();

                hubAmbient.Stop();
                cerradoAmbient.Stop();
                florestaAmbient.Stop();
                cavernaSource.Play();

                currentTime = 0f;
            break;
            default:
                hubSource.Stop();
                cerradoSource.Stop();
                florestaSource.Stop();
                cavernaSource.Stop();

                hubAmbient.Stop();
                cerradoAmbient.Stop();
                florestaAmbient.Stop();
                cavernaSource.Stop();

                currentTime = 0f;
            break;
        }
        
    }

    // Delay para iniciar a próxima música
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.25f); // O delay demora 125.0 ms (ou 1.25 segundos)
        change = true; // Variável de ativação para troca de música é ativada
        currentTime = 0f;
    }
}