﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour
{
    public GameObject keyUpInterface; // Icone de Interação
    public GameObject sceneChangeMessage; // Mensagem Base
    public GameObject sceneMessageFase; // Mensagens

    //public int cenaAtual;
    public int mudarParaCena;

    void Update()
    {
        // Gerador de mensagem de aceitação para mudar de cena
        // É perguntado ao jogador se ele deseja mudar de fase
        
    }

   /* private void OnTriggerEnter2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            Debug.Log(sceneMessageFase);
            Debug.Log(mudarParaCena);
        }
    }*/
    private void OnTriggerStay2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {

            keyUpInterface.SetActive(true);
            SceneChanger.triggered = true;
            //SceneChanger._cenaAtual = cenaAtual;
            SceneChanger._mudarParaCena = mudarParaCena;
            if (Input.GetButtonDown("Interacao") && SceneChanger.triggered == true && !SceneChanger.underProcess)
            {
                //Debug.Log(sceneMessageFase);
                //Debug.Log(mudarParaCena);
                sceneChangeMessage.SetActive(true); // liga o painel de mensagem
                sceneMessageFase.SetActive(true); // liga o texto "especifico"
                SceneChanger.underProcess = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            keyUpInterface.SetActive(false);
            SceneChanger.triggered = false;
            //SceneChanger._cenaAtual = cenaAtual;
            SceneChanger._mudarParaCena = mudarParaCena;
        }
    }
}
