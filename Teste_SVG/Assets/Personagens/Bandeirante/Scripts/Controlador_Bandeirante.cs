using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Bandeirante : MonoBehaviour
{
    private bool isFacingLeft = true;
    private float canShoot = 3f;
    protected bool isShooting = false;
    protected bool canReload = false;


    [SerializeField]
    private Transform[] posioesFase2;

    [SerializeField]
    protected Animator _anim;

    protected bool hit;

    [SerializeField]
    protected int HP = 5;

    [SerializeField]
    private Rigidbody2D projetil;

    [SerializeField]
    private Transform emissor;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private int vel;

    [SerializeField]
    private float ShootRate = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _anim.SetInteger("HP", HP);
    }

    // Update is called once per frame
    void Update()
    {

        canShoot -= Time.deltaTime;

        if (HP <= 0)
        {
            //_anim.SetBool("isDead", true);
            //Debug.Log("Ele morreu!");
        }
        else if (HP > 0 && HP <= 5)
        {
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
            // Debug.Log(canShoot);

            //Atira a cada "SootRate" segundos
            if ( canShoot < 0)
            {
                _anim.SetTrigger("Atira");
                canShoot = ShootRate;
                isShooting = true;
            }
        }
    }

    protected void Atira()
    {
        //Vector2 dir = new Vector2(-emissor.position.x, emissor.position.y);
        //Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation.normalized);
        if (isFacingLeft)
        {
            Rigidbody2D mao = Instantiate(projetil, emissor.position, Quaternion.identity);
            mao.AddForce(transform.right.normalized * -vel, ForceMode2D.Impulse);

        }
    }

    public void EndAtira()
    {
        _anim.SetTrigger("Recarrega");
        canReload = true;
        isShooting = false;
    }

    public void EndRecarga()
    {
        _anim.SetBool("Recarga", false);
        canReload = false;
    }


    protected void Dano()
    {
        if (canReload)
        {
            _anim.SetTrigger("Dano");
            if (canReload)
                canReload = false;
            HP--;
            _anim.SetInteger("HP", HP);
            StartCoroutine(Stun());
        }
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.2f);
        hit = false;
            
    }

}
