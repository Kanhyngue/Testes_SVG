using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTracing : MonoBehaviour
{
    public static int material;
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Grama"))
        {
            material = 0;
        }
        else if(col.gameObject.CompareTag("GramaFloresta"))
        {
            material = 1;
        }
        else if(col.gameObject.CompareTag("Terra"))
        {
            material = 2;
        }
        else if(col.gameObject.CompareTag("Madeira"))
        {
            material = 3;
        }
        else if(col.gameObject.CompareTag("Pedra"))
        {
            material = 4;
        }
        else if(col.gameObject.CompareTag("Umido"))
        {
            material = 5;
        }
    }
}
