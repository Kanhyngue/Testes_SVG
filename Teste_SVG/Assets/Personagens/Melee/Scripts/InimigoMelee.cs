using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMelee : MonoBehaviour
{
   
    public Transform player;
    public float enemySpeed;
    private bool chase;
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Se o jogador entrar do campo de visão do inimigo ele deixa de o perseguir
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           chase = true;
        }
    }

    // Se o jogador sair do campo de visão do inimigo ele deixa de o perseguir
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           chase = false; 
        }
    }

    void FixedUpdate()
    {
        // Persegue o Jogador
        if(chase)
        {
            anim.SetBool("perseguir", true);
            if(transform.position.x > player.position.x)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(-1,1,1);
            }
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
            
            // Ataca o jogador se ele estiver perto
            if(Vector2.Distance(transform.position, player.position) < 1.5f)
            {
                anim.SetBool("perseguir", false);
                anim.SetBool("atacar", true);
            }
            else
            {
                anim.SetBool("perseguir", true);
                anim.SetBool("atacar", false);
            }
        
        }
        else
        {
            anim.SetBool("perseguir", false);
        }
    }
}
