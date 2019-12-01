using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public GameObject sceneHub, sceneCerrado, sceneFloresta, sceneCaverna, sceneOca, sceneArena; // Scenes

    //public static int _cenaAtual; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final
    public static int _mudarParaCena; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final

    public static bool accepted = false;
    public static bool triggered = false;

    [SerializeField] private GameObject auraPlayer;

    public static bool underProcess = false;

    [SerializeField] SpriteRenderer[] telasLoad;  //0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final

    [SerializeField] Image panelLoad;
    private float telasLoadA;

    public void Acceptance()
{
    accepted = true;
    //if (accepted)
    //{
        switch (_mudarParaCena)
        {
            case 0:
            // Cenas ativadas
            sceneHub.SetActive(true);
               auraPlayer.SetActive(false);

            // Cenas desativadas
                sceneCerrado.SetActive(false);
                sceneFloresta.SetActive(false);
                sceneCaverna.SetActive(false);
                sceneOca.SetActive(false);
                sceneArena.SetActive(false);

                //Debug.Log("Entrou no switch-case HUB");
                //Debug.Log(_mudarParaCena);
                StartCoroutine(LoadScreen(_mudarParaCena));

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

                //Debug.Log("Entrou no switch-case cerrado");
                //Debug.Log(_mudarParaCena);
                StartCoroutine(LoadScreen(_mudarParaCena));

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

                //Debug.Log("Entrou no switch-case Floresta");
                //Debug.Log(_mudarParaCena);
                StartCoroutine(LoadScreen(_mudarParaCena));

                accepted = false;
                underProcess = false;
                break;
            case 3:
                // Cenas ativadas
                sceneCaverna.SetActive(true);
                auraPlayer.SetActive(true);

                // Cenas desativadas
                sceneHub.SetActive(false);
                sceneFloresta.SetActive(false);
                sceneCerrado.SetActive(false);
                sceneOca.SetActive(false);
                sceneArena.SetActive(false);

                //Debug.Log("Entrou no switch-case Caverna");
                //Debug.Log(_mudarParaCena);
                StartCoroutine(LoadScreen(_mudarParaCena));

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

                //Debug.Log("Entrou no switch-case Oca");
                //Debug.Log(_mudarParaCena);
                StartCoroutine(LoadScreen(_mudarParaCena));


                accepted = false;
                underProcess = false;
                break;
            case 5:
                // Cenas ativadas
                sceneArena.SetActive(true);
                auraPlayer.SetActive(false);

                // Cenas desativadas
                sceneHub.SetActive(false);
                sceneFloresta.SetActive(false);
                sceneCerrado.SetActive(false);
                sceneCaverna.SetActive(false);
                sceneOca.SetActive(false);

                //Debug.Log("Entrou no switch-case Arena");
                //Debug.Log(_mudarParaCena);
                StartCoroutine(LoadScreen(_mudarParaCena));

                accepted = false;
                underProcess = false;
                break;
            default:
                accepted = false;
                underProcess = false;
                break;
    }
}
    public void NotAcceptance()
    {
        accepted = false;
        underProcess = false;
    }

    IEnumerator LoadScreen(int i)
    {
        //Garante alpha 0(transparente), 1(Opaco)
        telasLoad[i].color = new Color(1, 1, 1, 0);
        panelLoad.color = new Color(0, 0, 0, 1);

        //Ativa o canvas e a respectiva imagem de Load de acordo com o "i" => 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final
        panelLoad.gameObject.SetActive(true);
        telasLoad[i].gameObject.SetActive(true);

        //Transiciona o alpha de 0 para 1 (transparente -> opaco)
        StartCoroutine(AlphaTela(1.0f, 1.0f, i));

        //Mantém o canvas ligado por  segundos
        yield return new WaitForSeconds(3);

        telasLoad[i].color = new Color(1, 1, 1, 1);
        panelLoad.color = new Color(0, 0, 0, 1);

        StartCoroutine(AlphaPanel(0.0f, 2.0f, i));

        StartCoroutine(AlphaPanel(0.0f, 1.0f));

        yield return new WaitForSeconds(3.0f);


        //Desativativa o canvas e a respectiva imagem de Load de acordo com o "i" => 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Arena Final
        panelLoad.gameObject.SetActive(false);
        telasLoad[i].gameObject.SetActive(false);
    }

    IEnumerator AlphaTela(float aValue, float aTime, int indice)
    {
        float alpha = telasLoad[indice].color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color corAlpha = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            telasLoad[indice].color = corAlpha;
            yield return null;
        }
        
    }

    IEnumerator AlphaPanel(float aValue, float aTime)
    {
        float alpha = panelLoad.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color corAlpha = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            //telasLoad[indice].color = corAlpha;
            panelLoad.color = corAlpha;
            yield return null;
        }

    }

    IEnumerator AlphaPanel(float aValue, float aTime, int indice)
    {
        float alpha = telasLoad[indice].color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color corAlpha = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            telasLoad[indice].color = corAlpha;
            //panelLoad.color = corAlpha;
            yield return null;
        }

    }




    public bool GetPanelState()
    {
        return panelLoad.gameObject.activeInHierarchy;
    }


}


