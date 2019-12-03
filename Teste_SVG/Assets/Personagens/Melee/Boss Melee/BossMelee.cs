using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    public Transform player;
    public float bossSpeed;
    public static bool _hit;
    private Animator anim;
    private int bossHealth = 100;
    private bool dead = false;
    private bool loopAttack = false;
    private bool dontWalk = false;
    public BoxCollider2D box;
    private bool chase;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        if(bossHealth <= 0 && !dead)
        {
            anim.SetTrigger("Death");
            anim.SetBool("isDead", true);
            dead = true;
            BossManager.florestaBossDefeated = true;
        }
        else if(!dead)
        {
            if(_hit)
            {
                anim.SetTrigger("GotHit");
                bossHealth--;
                Debug.Log(bossHealth);
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
        anim.SetTrigger("Recharge");
    }

    IEnumerator LoopAttack()
    {
        yield return new WaitForSeconds(3.0f);
        loopAttack = false;
        dontWalk = false;
    }
}
