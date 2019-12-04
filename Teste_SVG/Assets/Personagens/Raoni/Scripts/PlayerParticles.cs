using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    public ParticleSystem particles;
    public Transform player;

    [SerializeField]
    private Material[] materials;

    private void FootSprint() 
    {
        particles.Play();
        if (player.localScale.x > 0)
        {
            var shape = particles.shape;
            shape.rotation = new Vector3(0f,-90f,0f);
        }
        else
        {
            var shape = particles.shape;
            shape.rotation = new Vector3(0f, 90f, 0f);
        }
    }

    private void NonFootSprint() 
    {
        particles.Stop();
    }
}
