using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solta_Armadura : Controlador_Bandeirante
{

    public Rigidbody2D armadura;
    public Rigidbody2D capacete;
    public Rigidbody2D garrucha;
    public Rigidbody2D facao;

    public Transform solta_armadura;
    public Transform solta_capacete;
    public Transform solta_garrucha;
    public Transform solta_facao;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dano de jogador
        if (collision.gameObject.CompareTag("PlayerHit") )
        {
            Debug.Log("Coll BAnd");
            base.Dano();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
    }


/*    public void Tiro()
    {
        base.Atira();
    }*/

    public void SoltaArmadura()
    {
        Rigidbody2D armadura_solta = Instantiate(armadura, solta_armadura.transform.position, Quaternion.identity);
        armadura_solta.AddForce(Vector2.left * 01f, ForceMode2D.Impulse); ;
    }

    public void SoltaCapacete()
    {
        Rigidbody2D capacete_solto = Instantiate(capacete, solta_capacete.transform.position, Quaternion.identity);
        capacete_solto.AddForce(Vector2.right * 5, ForceMode2D.Impulse);

    }

    public void SoltaGarrucha()
    {
        Rigidbody2D garrucha_solta = Instantiate(garrucha, solta_garrucha.transform.position, Quaternion.identity);
        garrucha_solta.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
 
    }

    public void SoltaFacao()
    {
        Rigidbody2D facao_solto = Instantiate(facao, solta_facao.transform.position, Quaternion.identity);
        facao_solto.AddForce(Vector2.right * 5, ForceMode2D.Impulse);
    }

    public void EndTiro()
    {
        hit = false;
        _anim.SetBool("Dano", hit);
    }
}
