using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desbloqueiaCuriosidades : MonoBehaviour
{
    [SerializeField]
    private GameObject [] seletoresCuriosidadesTravados = new GameObject [8];
    [SerializeField]
    private GameObject[] seletoresCuriosidadesDestravados = new GameObject[8];

    // Start is called before the first frame update
    public void AtualizaQuadro()
    {
        int cont = 0;
        foreach (bool cachimbo in DataSystem.cachimbos)
        {
            if (cachimbo)
                cont++;
            switch (cont)
            {
                case 2:
                    seletoresCuriosidadesTravados[0].SetActive(false);
                    seletoresCuriosidadesDestravados[0].SetActive(true);
                    break;
                case 4:
                    seletoresCuriosidadesTravados[1].SetActive(false);
                    seletoresCuriosidadesDestravados[1].SetActive(true);
                    break;
                case 6:
                    seletoresCuriosidadesTravados[2].SetActive(false);
                    seletoresCuriosidadesDestravados[2].SetActive(true);
                    break;
                case 8:
                    seletoresCuriosidadesTravados[3].SetActive(false);
                    seletoresCuriosidadesDestravados[3].SetActive(true);
                    break;
                case 10:
                    seletoresCuriosidadesTravados[4].SetActive(false);
                    seletoresCuriosidadesDestravados[4].SetActive(true);
                    break;
                case 12:
                    seletoresCuriosidadesTravados[5].SetActive(false);
                    seletoresCuriosidadesDestravados[5].SetActive(true);
                    break;
                case 14:
                    seletoresCuriosidadesTravados[6].SetActive(false);
                    seletoresCuriosidadesDestravados[6].SetActive(true);
                    break;
                case 16:
                    seletoresCuriosidadesTravados[7].SetActive(false);
                    seletoresCuriosidadesDestravados[7].SetActive(true);
                    break;
                default:
                    break;
            }
        }

    }
}

    

