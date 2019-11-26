using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  ColetavelUI : MonoBehaviour
{
        public Text cachimboText;
        public Text powerText;
        public Text chaveText;
        public static bool activated;

    void LateUpdate()
    {
        if(activated)
        {
            cachimboText.text = DataSystem.cachimbos + " / 16";

            if(DataSystem.dashPower)
            {
                powerText.text = "1 / 3";
            }
            else if(DataSystem.firePower)
            {
                powerText.text = "2 / 3";
            }
            else if(DataSystem.fogPower)
            {
                powerText.text = "3 / 3";
            }
            else
            {
                powerText.text = "0 / 3";
            }

            if(DataSystem.chave)
            {
                chaveText.text = "1 / 1";
            }
            else
            {
                chaveText.text = "0 / 1";
            }
            activated = false;
        }
    }
}
