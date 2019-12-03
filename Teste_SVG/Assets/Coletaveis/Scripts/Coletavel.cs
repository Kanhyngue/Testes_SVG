using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    public Transform pullingArea;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Cachimbo"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.cachimbos++;
                ColetavelUI.activated = true;
                
            }
            else if(this.gameObject.CompareTag("Chave"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.chave = true;
                Paje_Controller.seletorFalaPaje++;
                NPC_Controller.seletorFalaNPC++;
            }
            else if(this.gameObject.CompareTag("Dash"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.dashPower = true;
                Paje_Controller.seletorFalaPaje++;
                NPC_Controller.seletorFalaNPC++;

            }
            else if(this.gameObject.CompareTag("Fire"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.firePower = true;
                Paje_Controller.seletorFalaPaje++;

            }
            else if(this.gameObject.CompareTag("Neblina"))
            {
                transform.position = pullingArea.transform.position;
                DataSystem.fogPower = true;
                Paje_Controller.seletorFalaPaje++;
                NPC_Controller.seletorFalaNPC++;

            }
        }
    }
}
