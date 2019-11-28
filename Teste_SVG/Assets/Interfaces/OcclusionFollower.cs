using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionFollower : MonoBehaviour
{
    public Transform player;
    public Transform occlusion;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.frameCount % 4 == 0)
        {
            occlusion.transform.position = player.transform.position;
        }
    }
}
