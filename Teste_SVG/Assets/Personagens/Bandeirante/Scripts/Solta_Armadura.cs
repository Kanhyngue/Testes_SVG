using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solta_Armadura : MonoBehaviour
{

    public Rigidbody2D armadura;
    public Rigidbody2D capacete;
    public Rigidbody2D garrucha;
    public Rigidbody2D facao;

    public Transform solta_armadura;
    public Transform solta_capacete;
    public Transform solta_garrucha;
    public Transform solta_facao;

    // Start is called before the first frame update
    void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
    }

    public void SoltaArmadura()
    {
        Rigidbody2D armadura_solta = Instantiate(armadura, solta_armadura.transform.position, solta_armadura.transform.rotation);
        if (transform.localScale.x == -1)
        {
            armadura_solta.transform.localScale = new Vector3(1.0f , 1.0f , 1.0f);
            //armadura_solta.AddForce(Vector2.left * 5);
        }
        else if (transform.localScale.x == -1)
        {
            armadura_solta.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            //armadura_solta.AddForce(Vector2.right * 5);
        }
    }

    public void SoltaCapacete()
    {
        Rigidbody2D capacete_solto = Instantiate(capacete, solta_capacete.transform.position, solta_capacete.transform.rotation);
        if (transform.localScale.x == 1)
        {
            capacete_solto.AddForce(Vector2.left * 500);
        }
        else if (transform.localScale.x == -1)
        {
            capacete_solto.AddForce(Vector2.right * 500);
        }
    }
    public void SoltaGarrucha()
    {
        Rigidbody2D garrucha_solta = Instantiate(garrucha, solta_garrucha.transform.position, solta_garrucha.transform.rotation);
        if (transform.localScale.x == 1)
        {
            garrucha_solta.AddForce(Vector2.right * 500);
        }
        else if (transform.localScale.x == -1)
        {
            garrucha_solta.AddForce(Vector2.left * 500);
        }
    }
    public void SoltaFacao()
    {
        Rigidbody2D facao_solto = Instantiate(facao, solta_facao.transform.position, solta_facao.transform.rotation);
        if (transform.localScale.x == 1)
        {
            facao_solto.AddForce(Vector2.left * 100);
        }
        else if (transform.localScale.x == -1)
        {
            facao_solto.AddForce(Vector2.right * 100);
        }
    }
}
