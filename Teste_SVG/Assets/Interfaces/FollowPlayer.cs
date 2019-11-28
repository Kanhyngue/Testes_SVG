using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Transform keyUpArrow;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.frameCount % 1 == 0)
        {
            keyUpArrow.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, 0.0f);
        }
    }
}
