using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Tiro : MonoBehaviour
{
    [SerializeField] private Transform braco;
    private bool dead;
    private Vector3 p_Pos;

    //[SerializeField]
    private Animator _anim;
    private bool isFacingLeft = true;
    public bool hit { get; private set; }
    public int enemyHealth = 20;

    [SerializeField]
    private int vel;

    [SerializeField]
    private Rigidbody2D projetil;

    [SerializeField]
    private Transform emissor = null;

    [SerializeField]
    private Transform player;



    private void Start()
    {
        //braco = transform.Find("Braco");
        _anim = GetComponentInChildren<Animator>();
        isFacingLeft = transform.localScale.x > 0;
    }

    private void Update()
    {
        if (enemyHealth <= 0 && !dead)
        {
            _anim.SetTrigger("Death");
            _anim.SetBool("isDead", true);
            dead = true;
            //Debug.Log("Ele morreu!");
        }
        else if (!dead)
        {
                p_Pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

                //ajuste de mira, dependendo do lado que estiver olhando
                if (isFacingLeft)
                    braco.transform.right = (p_Pos - braco.transform.position) * -1;
                else
                    braco.transform.right = (p_Pos - braco.transform.position);

                //Flip, dependendo da posição do jogador
                if (isFacingLeft && player.transform.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    isFacingLeft = transform.localScale.x > 0;
                }
                else if (!isFacingLeft && player.transform.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    isFacingLeft = transform.localScale.x > 0;
                }
        }
    }
    //
    public void Atira()
    {
        //Vector2 dir = new Vector2(-emissor.position.x, emissor.position.y);
        //Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation.normalized);
        if (isFacingLeft)
        {
            Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation.normalized);
            mao.AddForce(braco.transform.right.normalized * -vel, ForceMode2D.Impulse);
        }
        else
        {
            Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation.normalized);
            mao.transform.localScale = new Vector3(-mao.transform.localScale.x, mao.transform.localScale.y, mao.transform.localScale.z);
            mao.AddForce(braco.transform.right.normalized * vel, ForceMode2D.Impulse);
        }
    }

    //compo de visão
    void OnTriggerStay2D(Collider2D col)
    {
        //Nota e mira no jogador
        if (col.gameObject.CompareTag("Player"))
        {
            _anim.SetTrigger("IsAiming");
        }
    }

    //Contato
    public void Dano ()
    {
        hit = true;
        _anim.SetTrigger("GotHit");
        enemyHealth--;
        //rig.AddForce(transform.right * hitKnockback);
        StartCoroutine(Stun());
        Debug.Log(enemyHealth);
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.2f);
        hit = false;
    }

    public void Destroi()
    {
        Destroy(gameObject);
    }
}
