using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public Transform pullingArea;
    public int cachimboArea; // 0 até 2 -> HUB | 3 até 7 -> Cerrado | 8 até 11 -> Floresta | 12 até 15 -> Caverna
    private bool collected = false;

    private void Update()
    {
        if (this.gameObject.CompareTag("Cachimbo") && !collected)
        {
            for (int i = 0; i < DataSystem.cachimbos.Length; i++)
            {
                if (DataSystem.cachimbos[i] && cachimboArea == i)
                {
                    transform.position = pullingArea.transform.position;
                    collected = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Cachimbo"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.cachimbos[cachimboArea] = true;
                ColetavelUI.activated = true;
                
            }
            else if(this.gameObject.CompareTag("Chave"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.chave = true;
                Paje_Controller.seletorFalaPaje = 8;
                NPC_Controller.seletorFalaNPC++;
            }
            else if(this.gameObject.CompareTag("Dash"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.dashPower = true;
                Paje_Controller.seletorFalaPaje = 2;
                NPC_Controller.seletorFalaNPC++;

            }
            else if(this.gameObject.CompareTag("Fire"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.firePower = true;
                Paje_Controller.seletorFalaPaje = 4;

            }
            else if(this.gameObject.CompareTag("Neblina"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.fogPower = true;
                Paje_Controller.seletorFalaPaje = 6;
                NPC_Controller.seletorFalaNPC++;

            }
        }
    }
}
