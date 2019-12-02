using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    public Transform limiteUp, limiteDown;

    private float moveSpeed = 3.0f;

    public bool horizontal;

    private bool moveUp = true;

    // Update is called once per frame
    void LateUpdate()
    {
        if(horizontal)
        {
            if(transform.position.x > limiteUp.position.x)
            {
                moveUp = false;
            }
            else if (transform.position.x < limiteDown.position.x)
            {
                moveUp = true;
            }

            if(moveUp)
            {
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            }
        }
        else
        {
            if(transform.position.y > limiteUp.position.y)
            {
                moveUp = false;
            }
            else if (transform.position.y < limiteDown.position.y)
            {
                moveUp = true;
            }

            if(moveUp)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
            }
        }
    }
}
