using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioSource hubSource, cerradoSource, florestaSource, cavernaSource;
    public GameObject hub, cerrado, floresta, caverna;
    public float fadeOffDuration;
    private float startTime = 1f;
    private float currentTime = 0f;
    private int cena;
    private bool change = false;

    void Update()
    {
        VerificarCena();
    }

    void VerificarCena()
    {
        if(hub.activeSelf && cena != 0)
        {
            if(change)
            {
                cena = 0;
                AtribuirSource(0);
            }
            else
            {
                FadeMusic();
            }
        }
        else if(cerrado.activeSelf && cena != 1)
        {
            if(change)
            {
                cena = 1;
                AtribuirSource(1);
            }
            else
            {
                FadeMusic();
            }
        }
        else if(floresta.activeSelf && cena != 2)
        {
            if(change)
            {
                cena = 2;
                AtribuirSource(2);
            }
            else
            {
                FadeMusic();
            }
        }
        else if(caverna.activeSelf && cena != 3)
        {
            if(change)
            {
                cena = 3;
                AtribuirSource(3);
            }
            else
            {
                FadeMusic();
            }
        }
    }

    public void FadeMusic()
    {   
        switch(cena)
        {
            case 0:
                if(currentTime < fadeOffDuration)
                {
                    currentTime += Time.deltaTime;
                    hubSource.volume = Mathf.Lerp(startTime, 0f, currentTime / fadeOffDuration);
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
                    cerradoSource.volume = Mathf.Lerp(startTime, 0f, currentTime / fadeOffDuration);
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
                    florestaSource.volume = Mathf.Lerp(startTime, 0f, currentTime / fadeOffDuration);
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
                    cavernaSource.volume = Mathf.Lerp(startTime, 0f, currentTime / fadeOffDuration);
                }
                else
                {
                    StartCoroutine(Delay());
                }
            break;
            default:
                // do anything
            break;
        }
    }

    public void AtribuirSource(int _cena)
    {
        switch(_cena)
        {
            case 0:
                hubSource.Play();
                cerradoSource.Stop();
                florestaSource.Stop();
                cavernaSource.Stop();
                change = false;
                hubSource.volume = 1f;
                cerradoSource.volume = 1f;
                florestaSource.volume = 1f;
                cavernaSource.volume = 1f;
            break;
            case 1:
                cerradoSource.Play();
                hubSource.Stop();
                florestaSource.Stop();
                cavernaSource.Stop();
                change = false;
                hubSource.volume = 1f;
                cerradoSource.volume = 1f;
                florestaSource.volume = 1f;
                cavernaSource.volume = 1f;
            break;
            case 2:
                florestaSource.Play();
                cerradoSource.Stop();
                hubSource.Stop();
                cavernaSource.Stop();
                change = false;
                hubSource.volume = 1f;
                cerradoSource.volume = 1f;
                florestaSource.volume = 1f;
                cavernaSource.volume = 1f;
            break;
            case 3:
                cavernaSource.Play();
                cerradoSource.Stop();
                florestaSource.Stop();
                hubSource.Stop();
                change = false;
                hubSource.volume = 1f;
                cerradoSource.volume = 1f;
                florestaSource.volume = 1f;
                cavernaSource.volume = 1f;
            break;
            default:
                hubSource.Stop();
                cerradoSource.Stop();
                florestaSource.Stop();
                cavernaSource.Stop();
                change = false;
                hubSource.volume = 1f;
                cerradoSource.volume = 1f;
                florestaSource.volume = 1f;
                cavernaSource.volume = 1f;
            break;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.25f);
        change = true;
    }
}
