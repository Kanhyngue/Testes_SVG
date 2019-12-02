using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{

    [SerializeField] private float speed;
    private Rigidbody2D rb2D;
    [SerializeField] private GameObject hitEffect = null;
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
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            GameObject eff = Instantiate(hitEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            rb2D.velocity = Vector2.zero;
            Destroy(gameObject, 1.4f);
            Destroy(eff.gameObject, 1.4f);
        }
        else if (collision.gameObject.CompareTag("Inimigo") && Vector2.Distance(transform.position, collision.gameObject.transform.position) < 1.5f)
        {
            GameObject eff = Instantiate(hitEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            rb2D.velocity = Vector2.zero;
            Destroy(gameObject, 1.4f);
            Destroy(eff.gameObject, 1.4f);
        }
        else if(collision.gameObject.CompareTag("TochaApagada"))
        {
            GameObject eff = Instantiate(hitEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            rb2D.velocity = Vector2.zero;
            Destroy(gameObject, 1.4f);
            Destroy(eff.gameObject, 1.4f);
        }
    }

}
