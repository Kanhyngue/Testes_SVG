using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Tiro : MonoBehaviour
{
    private Transform braco;
    
    private Vector3 p_Pos;

    [SerializeField]
    private int vel;

    [SerializeField]
    private Rigidbody2D projetil;

    [SerializeField]
    private Transform emissor = null;

    [SerializeField]
    private Transform player;

    private Animator _anim;
    private bool isFacingLeft = true;
    private bool hit;
    private int enemyHealth = 20;

    private void Start()
    {
        braco = transform.GetChild(0);
        _anim = GetComponent<Animator>();
        isFacingLeft = transform.localScale.x > 0;
    }

    private void Update()
    {
        p_Pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) ;

        //ajuste de mira, dependendo do lado que estiver olhando
        if(isFacingLeft)
            braco.transform.right = (p_Pos - braco.transform.position) * -1;
        else
            braco.transform.right = (p_Pos - braco.transform.position);

        //Flip, dependendo da posição do jogador
        if (isFacingLeft && player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingLeft = transform.localScale.x > 0;
        }else if (!isFacingLeft && player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingLeft = transform.localScale.x > 0;
        }
    }

    //
    public void Atira()
    {
        Vector2 dir = new Vector2(-emissor.position.x, emissor.position.y);
        Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation.normalized);
        if (isFacingLeft)
            mao.AddForce(braco.transform.right.normalized * -vel, ForceMode2D.Impulse);
        else
            mao.AddForce(braco.transform.right.normalized * vel, ForceMode2D.Impulse);

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dano de jogador
        if (collision.gameObject.CompareTag("PlayerHit"))
        {
            hit = true;
            Debug.Log(enemyHealth);
        }
    }
}
