using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject particles;
    public int checkpointArea;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("O player tocou o checkpoint.");
            CheckpointSystem.checkpoint = checkpointArea;
            particles.SetActive(true);
        }
    }

    private void Update()
    {
        if (checkpointArea != CheckpointSystem.checkpoint)
        {
            particles.SetActive(false);
        }
    }
}
