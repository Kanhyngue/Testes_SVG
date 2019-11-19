using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int cenaCheckpoint;
    public bool middle; // se é começo de fase ou meio da fase
    private int healthTest = 3;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(middle)
            {
                DataSystem.checkpoint = true;
                DataSystem.level = cenaCheckpoint;
                DataSystem.activated = true;
                DataSystem.health = healthTest;
            }
            else
            {
                DataSystem.checkpoint = false;
                DataSystem.level = cenaCheckpoint;
                DataSystem.activated = true;
                DataSystem.health = healthTest;
            }
            Debug.Log("O player tocou o checkpoint.");
            
        }
    }
}
