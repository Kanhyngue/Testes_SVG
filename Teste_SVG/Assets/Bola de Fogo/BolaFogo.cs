using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{

    [SerializeField] private float speed;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {            
        Destroy(gameObject, 3f);
    }

}
