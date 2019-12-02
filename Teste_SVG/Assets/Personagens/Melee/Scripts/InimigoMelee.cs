using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMelee : MonoBehaviour
{
    public Transform player;
    public float enemySpeed;
    public float hitKnockback = 10.0f;
    private bool chase;
    private bool hit;
    private Animator anim;
    private int enemyHealth = 20;
    private Rigidbody2D rig;
    private bool dead = false;
    private bool loopAttack = false;
    private bool dontWalk = false;
    public BoxCollider2D box;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Se o jogador entrar do campo de visão do inimigo ele deixa de o perseguir
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           chase = true;
        }

        if((col.gameObject.CompareTag("PlayerHit")) && Vector2.Distance(transform.position,player.position) < 1.5f)
        {
            hit = true;
            Debug.Log(enemyHealth);
        }

        if(col.gameObject.CompareTag("Tiro") && Vector2.Distance(transform.position, col.gameObject.transform.position) < 1.5f)
        {
            hit = true;
            Debug.Log(enemyHealth);
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
        if(enemyHealth <= 0 && !dead)
        {
            anim.SetTrigger("Death");
            anim.SetBool("isDead", true);
            dead = true;
            //Debug.Log("Ele morreu!");
        }
        else if(!dead)
        {
            if(hit)
            {
                anim.SetTrigger("GotHit");
                enemyHealth--;
                rig.AddForce(transform.right * hitKnockback);
                StartCoroutine(Stun());
            }
            else
            {
                // Persegue o Jogador
                if(chase)
                {
                    if(transform.position.x > player.position.x)
                    {
                        transform.localScale = new Vector3(1,1,1);
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1,1,1);
                    }

                    // Ataca o jogador se ele estiver perto
                    if(Vector2.Distance(transform.position, player.position) < 1.35f && !loopAttack)
                    {
                        anim.SetBool("perseguir", false);
                        anim.SetBool("atacar", true);
                        loopAttack = true;
                        dontWalk = true;
                        StartCoroutine(LoopAttack());
                    }
                    else if(!dontWalk)
                    {
                        anim.SetBool("perseguir", true);
                        anim.SetBool("atacar", false);
                        transform.position = Vector2.MoveTowards(transform.position, player.position, enemySpeed * Time.deltaTime);
                    }
                }
                else
                {
                    anim.SetBool("perseguir", false);
                }
            }       
        }
        else if(dead)
        {
            box.enabled = false;
        }
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.2f);
        hit = false;
    }

    IEnumerator LoopAttack()
    {
        yield return new WaitForSeconds(0.5f);
        loopAttack = false;
        dontWalk = false;
    }
}
