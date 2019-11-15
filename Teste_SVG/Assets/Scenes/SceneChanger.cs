using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject keyUpInterface;
    public GameObject sceneHub;
    public GameObject sceneCerrado;
    public GameObject sceneFloresta;
    public GameObject sceneCaverna;
    public GameObject sceneOca;

    public int cenaAtual; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Menu / 6 -> Créditos
    public int mudarParaCena; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Menu / 6 -> Créditos

    private bool triggered;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && triggered == true)
        {
            if(cenaAtual == 0)
            {
                switch (mudarParaCena)
                {
                    case 0:
                        // Faz nada, não tem como entrar na cena já carregada
                    break;
                    case 1:
                        sceneHub.SetActive(false);
                        sceneCerrado.SetActive(true);
                    break;
                    case 2:
                        sceneHub.SetActive(false);
                        sceneFloresta.SetActive(true);
                    break;
                    case 3:
                        sceneHub.SetActive(false);
                        sceneCaverna.SetActive(true);
                    break;
                    case 4:
                        sceneHub.SetActive(false);
                        sceneOca.SetActive(true);
                    break;
                    default:
                        // Faz nada também
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            keyUpInterface.SetActive(true);
            triggered = true;
        }
    }
    private void OnTriggerStay2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            keyUpInterface.SetActive(true);
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            keyUpInterface.SetActive(false);
            triggered = false;
        }
    }
}
