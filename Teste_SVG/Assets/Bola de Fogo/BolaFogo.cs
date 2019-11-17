using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private LayerMask m_WhatIsGround;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (transform.rotation.y < 0)
        {

            rb2D.velocity = transform.right * speed * 1;
        }
        else if (transform.rotation.y > 0)
        {
            rb2D.velocity = transform.right * speed * -1;
        }

    }


    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }else
        {
            Destroy(gameObject, 3f);
        }
    }

}
