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


    private void Start()
    {
        braco = transform.GetChild(0);
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        p_Pos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z) ;
        braco.transform.right = (p_Pos - braco.transform.position) * -1; 
    }

    public void Atira()
    {
        Vector2 dir = new Vector2(-emissor.position.x, emissor.position.y);
        Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation.normalized);
        /*        Transform _tMao = mao.GetComponent<Transform>();
        */
        mao.transform.position = Vector2.MoveTowards(mao.transform.position, p_Pos.normalized, vel);
 //       mao.transform.rotation = new Quaternion(0,0,0,0);
        mao.AddForce((p_Pos.normalized), ForceMode2D.Impulse);
        Destroy.(mao, 2f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _anim.SetTrigger("IsAiming");
        }
    }
}
