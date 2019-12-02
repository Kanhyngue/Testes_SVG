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
        if (collision.gameObject.CompareTag("Tiro") && base._anim.GetBool("Recarrega"))
        {
            Debug.Log("Coll BAnd");
            base.Dano();
        }else if (collision.gameObject.CompareTag("Tiro") && (base._anim.GetBool("Idle") || isShooting))
        {
            _anim.SetBool("Defesa", true);
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
        armadura_solta.AddForce(Vector2.left, ForceMode2D.Impulse); ;
    }

    public void SoltaCapacete()
    {
        Rigidbody2D capacete_solto = Instantiate(capacete, solta_capacete.transform.position, Quaternion.identity);
        capacete_solto.AddForce(Vector2.left *2, ForceMode2D.Impulse);

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

    public void EndAtira()
    {
        //base._anim.SetBool("Recarrega", true);
        base.isShooting = false;
    }

    public void EndRecarga()
    {
        base._anim.SetBool("Recarga", false);
        
    }
       
}
