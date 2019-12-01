using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Tiro : MonoBehaviour
{
    private Transform braco;
    private Vector2 p_Pos;

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
        braco = transform.GetChild(0);
    }

    private void Update()
    {
        p_Pos = new Vector3(player.transform.position.x, player.transform.position.y);
        braco.transform.right = p_Pos * -1;

    }

    public void Atira ()
    {
        Vector2 dir = new Vector2(emissor.position.x, emissor.position.y);
        Rigidbody2D mao = Instantiate(projetil, emissor.position, emissor.rotation);
        mao.AddForce(p_Pos.normalized * vel);
    }

}
