using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaFeedback : MonoBehaviour
{
    private int _health = 5;
    public List<SpriteRenderer> vida;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_health != DataSystem.health)
        {
            _health = DataSystem.health;
            for(int i = 0; i < 5; i++)
            {
                if(i <= _health - 1)
                {
                    vida[i].enabled = true;
                }
                else
                {
                    vida[i].enabled = false;
                }
            }
        }
    }
}
