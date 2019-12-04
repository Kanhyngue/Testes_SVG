using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxHUB : MonoBehaviour
{

    public Transform player;
    public float speedCoefficient;

    void Start()
    {
    }

    void Update()
    {
        transform.position = new Vector2(player.position.x, player.position.y);
    }
}
