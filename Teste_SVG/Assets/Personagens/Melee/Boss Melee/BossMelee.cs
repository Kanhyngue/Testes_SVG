using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public Transform player;
    public float bossSpeed;
    private bool _hit;
    private Animator anim;
    private int bossHealth = 500;
    private bool dead = false;
    private bool loopAttack = false;
    private bool dontWalk = false;
    public BoxCollider2D box;
    private bool chase;

    // Se o jogador entrar do campo de visão do inimigo ele deixa de o perseguir
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
           chase = true;
        }

        if(col.gameObject.CompareTag("PlayerHit"))
        {
            _hit = true;
            Debug.Log(bossHealth);
        }
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        _hit = BossMeleeHitBox.hit;
        if(bossHealth <= 0 && !dead)
        {
            anim.SetTrigger("Death");
            anim.SetBool("isDead", true);
            dead = true;
            //Debug.Log("Ele morreu!");
        }
        else if(!dead)
        {
            if(_hit)
            {
                anim.SetTrigger("GotHit");
                bossHealth--;
                StartCoroutine(Stun());
            }
            else
            {
                // Flipa o sprite de acordo com a direção do player
                if(!anim.GetBool("atacar"))
                {
                    if(transform.position.x > player.position.x)
                    {
                        transform.localScale = new Vector3(1,1,1); // direciona-se para a esquerda
                    }
                    else
                    {
                        transform.localScale = new Vector3(-1,1,1); // direciona-se para a direita
                    }
                }
                
                // Ataca o jogador se ele estiver perto
                if(Vector2.Distance(transform.position, player.position) < 3.5f && !loopAttack)
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
                    transform.position = Vector2.MoveTowards(transform.position, player.position, bossSpeed * Time.deltaTime);
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
        yield return new WaitForSeconds(1.0f);
        _hit = false;
    }

    IEnumerator LoopAttack()
    {
        yield return new WaitForSeconds(3.0f);
        loopAttack = false;
        dontWalk = false;
    }
}
