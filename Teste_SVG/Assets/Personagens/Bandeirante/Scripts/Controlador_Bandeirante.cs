using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador_Bandeirante : MonoBehaviour
{
    protected bool isFacingLeft = true;
    private float canShoot = 3f;
    protected bool isShooting = false;
    protected bool canReload = false;
    private bool fase1 = true;


    [SerializeField]
    private Transform[] posicoesFase2;

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
    private Vector3 p_pos;

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
        checkPlayerOver();

        if ((HP > 0 && HP <= 5) && !fase1 && !_anim.GetCurrentAnimatorStateInfo(0).IsTag("Defesa"))
        {

            canShoot -= Time.deltaTime;
            switch (HP)
            {
                case 4:
                    if (_anim.GetCurrentAnimatorStateInfo(0).IsTag("Tira"))
                    {
                        canShoot = 10f;
                        _anim.SetInteger("HP", HP);
                        break;
                    } else if (_anim.GetBool("IsMoving"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, posicoesFase2[0].position, vel * Time.deltaTime);
                        if (Vector2.Distance(transform.position, posicoesFase2[0].position) <= 0.1f)
                        {
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            _anim.SetBool("IsMoving", false);
                            canShoot = ShootRate;
                        }
                    }
                    else if (_anim.GetBool("IsRunning"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, p_pos, vel * 1.5f * Time.deltaTime);
                        if (Vector2.Distance(transform.position, p_pos) <= 0.5f)
                        {
                            _anim.SetBool("IsRunning", false);
                            _anim.SetTrigger("Atira");
                            isShooting = true;
                            canShoot = 10f;
                        }
                    }

                    if (canShoot < 0)
                    {
                        _anim.SetBool("IsRunning", true);
                        p_pos = new Vector3(player.position.x, 0.9663032f, 0f);
                        canShoot = 10f;
                    }
                    break;
                case 3:
                    if (_anim.GetBool("IsMoving"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, posicoesFase2[1].position, vel * Time.deltaTime);
                        if (Vector2.Distance(transform.position, posicoesFase2[1].position) <= 0.1f)
                        {
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            _anim.SetBool("IsMoving", false);
                            canShoot = ShootRate;
                        }
                    }
                    else if (_anim.GetBool("IsRunning"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, p_pos, vel * 1.5f * Time.deltaTime);
                        if (Vector2.Distance(transform.position, p_pos) <= 0.5f)
                        {
                            _anim.SetBool("IsRunning", false);
                            _anim.SetTrigger("Atira");
                            isShooting = true;
                            canShoot = 20;
                        }
                    }

                    if (canShoot < 0)
                    {
                        _anim.SetBool("IsRunning", true);
                        p_pos = new Vector3(player.position.x, 0.9663032f, 0f);
                        canShoot = 20;
                    }
                    break;

                case 2:
                    if (_anim.GetBool("IsMoving"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, posicoesFase2[2].position, vel * Time.deltaTime);
                        if (Vector2.Distance(transform.position, posicoesFase2[2].position) <= 0.1f)
                        {
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            _anim.SetBool("IsMoving", false);
                            canShoot = ShootRate;
                        }
                    }
                    else if (_anim.GetBool("IsRunning"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, p_pos, vel * 1.5f * Time.deltaTime);
                        if (Vector2.Distance(transform.position, p_pos) <= 0.5f)
                        {
                            _anim.SetBool("IsRunning", false);
                            _anim.SetTrigger("Atira");
                            isShooting = true;
                            canShoot = 20;
                        }
                    }

                    if (canShoot < 0)
                    {
                        _anim.SetBool("IsRunning", true);
                        p_pos = new Vector3 (player.position.x, 0.9663032f, 0f);
                        canShoot = 20;
                    }
                    break;

                case 1:
                    if (_anim.GetBool("IsMoving"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, posicoesFase2[3].position, vel * Time.deltaTime);
                        if (Vector2.Distance(transform.position, posicoesFase2[3].position) <= 0.1f)
                        {
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            _anim.SetBool("IsMoving", false);
                        }
                    }
                    else if (_anim.GetBool("IsRunning"))
                    {
                        transform.position = Vector2.MoveTowards(transform.position, p_pos, vel * 1.5f * Time.deltaTime);
                        if (Vector2.Distance(transform.position, p_pos) <= 0.5f)
                        {
                            _anim.SetBool("IsRunning", false);
                            _anim.SetTrigger("Atira");
                            isShooting = true;
                            canShoot = 10;
                        }
                    }

                    if (canShoot < 0)
                    {
                        _anim.SetBool("IsRunning", true);
                        p_pos = new Vector3(player.position.x, 0.9663032f, 0f);
                        canShoot = 10;
                    }
                    break;

                case 0:
                    
                    break;
            }
        }
        else if ((HP > 0 && HP <= 5) && fase1)
        {

            canShoot -= Time.deltaTime;
            //Flip, dependendo da posição do jogador
            /*            if (isFacingLeft && player.transform.position.x > transform.position.x)
                        {
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            isFacingLeft = transform.localScale.x > 0;
                        }
                        else if (!isFacingLeft && player.transform.position.x < transform.position.x)
                        {
                            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                            isFacingLeft = transform.localScale.x > 0;
                        }*/
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
        canReload = false;
    }


    protected void Dano()
    {
        if (canReload && fase1)
        {
            Debug.Log("Dano Fase 1");
            _anim.SetTrigger("Dano");
            if (canReload)
                canReload = false;
            HP--;
            _anim.SetInteger("HP", HP);
            StartCoroutine(Stun());
            if(HP == 0)
            {
                fase1 = false;
                HP = 4;
            }
        }else if( !fase1 )
        {
            Debug.Log("Dano Fase 2");
            _anim.SetTrigger("Dano");
            HP--;
            _anim.SetInteger("HP", HP);
            canShoot = ShootRate;
            _anim.SetBool("IsRunning", false);
            if (HP == 0)
            {
                _anim.SetBool("IsDead", true);
                return;
            }

            StartCoroutine(Stun2());
        }
    }

    public void EndFacada()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _anim.SetBool("IsMoving", true);
    }

    private void checkPlayerOver()
    {
        if (player.transform.position.y >= 4.5f && ((player.transform.position.x - transform.position.x) <= 1.5f) )
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
            {
                _anim.SetTrigger("Bloqueio");
            }
        }
    }
    IEnumerator Stun()
    {
        yield return new WaitForSeconds(0.2f);
        hit = false;
            
    }
    IEnumerator Stun2()
    {
        yield return new WaitForSeconds(.5f);
        if(isFacingLeft)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        _anim.SetBool("IsMoving", true);

    }
}
