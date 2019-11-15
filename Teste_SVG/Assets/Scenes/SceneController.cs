using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static uint cenaAtual; // 0 -> HUB / 1 -> Cerrado / 2 -> Floresta / 3 -> Caverna / 4 -> Oca do Jogador / 5 -> Menu Principal / 6 -> Créditos

    // Start is called before the first frame update
    void Start()
    {
        cenaAtual = 0;
    }

}
