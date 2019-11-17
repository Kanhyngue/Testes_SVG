using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    public GameObject sceneHub, sceneCerrado, sceneFloresta, sceneCaverna, sceneOca, sceneArena; // Scenes

    public static int _cenaAtual; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final
    public static int _mudarParaCena; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final

    public static bool accepted = false;
    public static bool triggered = false;

    public static bool underProcess = false;

    // Update is called once per frame
    void Update()
    {
        // Se o Jogador clicar em sim
        // Muda de cena
        if(accepted)
        {
            switch(_mudarParaCena)
            {
                case 0:
                    // Cenas ativadas
                    sceneHub.SetActive(true);

                    // Cenas desativadas
                    sceneCerrado.SetActive(false);
                    sceneFloresta.SetActive(false);
                    sceneCaverna.SetActive(false);
                    sceneOca.SetActive(false);
                    sceneArena.SetActive(false);
                    accepted = false;
                    underProcess = false;
                break;
                case 1:
                    // Cenas ativadas
                    sceneCerrado.SetActive(true);

                    // Cenas desativadas
                    sceneHub.SetActive(false);
                    sceneFloresta.SetActive(false);
                    sceneCaverna.SetActive(false);
                    sceneOca.SetActive(false);
                    sceneArena.SetActive(false);
                    accepted = false;
                    underProcess = false;
                break;
                case 2:
                    // Cenas ativadas
                    sceneFloresta.SetActive(true);

                    // Cenas desativadas
                    sceneHub.SetActive(false);
                    sceneCerrado.SetActive(false);
                    sceneCaverna.SetActive(false);
                    sceneOca.SetActive(false);
                    sceneArena.SetActive(false);
                    accepted = false;
                    underProcess = false;
                break;
                case 3:
                    // Cenas ativadas
                    sceneCaverna.SetActive(true);

                    // Cenas desativadas
                    sceneHub.SetActive(false);
                    sceneFloresta.SetActive(false);
                    sceneCerrado.SetActive(false);
                    sceneOca.SetActive(false);
                    sceneArena.SetActive(false);
                    accepted = false;
                    underProcess = false;
                break;
                case 4:
                    // Cenas ativadas
                    sceneOca.SetActive(true);

                    // Cenas desativadas
                    sceneHub.SetActive(false);
                    sceneFloresta.SetActive(false);
                    sceneCerrado.SetActive(false);
                    sceneCaverna.SetActive(false);
                    sceneArena.SetActive(false);
                    accepted = false;
                    underProcess = false;
                break;
                case 5:
                    // Cenas ativadas
                    sceneArena.SetActive(true);

                    // Cenas desativadas
                    sceneHub.SetActive(false);
                    sceneFloresta.SetActive(false);
                    sceneCerrado.SetActive(false);
                    sceneCaverna.SetActive(false);
                    sceneOca.SetActive(false);
                    accepted = false;
                    underProcess = false;
                break;
                default:
                    accepted = false;
                    underProcess = false;
                break;
            }
        }
    }

    public void Acceptance()
    {
        accepted = true;
    }

}
