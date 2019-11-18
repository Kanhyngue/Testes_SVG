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
                InventorySystem.cachimboColetados++;
            }
            else if(this.gameObject.CompareTag("Chave"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.chaveColetada = true;
            }
            else if(this.gameObject.CompareTag("Dash"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.dashPowerColetado = true;
            }
            else if(this.gameObject.CompareTag("Fire"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.firePowerColetado = true;
            }
            else if(this.gameObject.CompareTag("Neblina"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.fogPowerColetado = true;
            }
        }
    }

    /* public Coletavel (InventorySystem inventory)
    {
        inventory.cachimbos = cachimboColetados;
        inventory.chave = chaveColetada;
        inventory.dashPower = dashPowerColetado;
        inventory.firePower = firePowerColetado;
        inventory.fogPower = fogPowerColetado;
    }*/
}
