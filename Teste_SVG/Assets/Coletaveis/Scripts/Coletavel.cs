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
                InventorySystem.cachimbos++; 
            }
            else if(this.gameObject.CompareTag("Chave"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.chave = true; 
            }
            else if(this.gameObject.CompareTag("Dash"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.dashPower = true; 
            }
            else if(this.gameObject.CompareTag("Fire"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.firePower = true; 
            }
            else if(this.gameObject.CompareTag("Neblina"))
            {
                transform.position = pullingArea.transform.position;
                InventorySystem.fogPower = true; 
            }
        }
    }
}
