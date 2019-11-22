using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timer = 5.0f;

    public ParticleSystem particle1;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Partcle());
        
    }

    IEnumerator Partcle()
    {
        if(!particle1.isPlaying)
        {
            yield return new WaitForSeconds(5);
            particle1.Play(); // turn the particle system on
        }
        
    }
}
