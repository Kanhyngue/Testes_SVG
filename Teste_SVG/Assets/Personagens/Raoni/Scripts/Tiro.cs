using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D rbd2d;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform tiroPoint;
    private Player_Control pl;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        pl = player.gameObject.GetComponent<Player_Control>();
        anim = player.gameObject.GetComponent<Animator>();
    }
    public void Atirar()
    {
        if (player.localScale.x == 0.22f)
        {
            Rigidbody2D tiro = Instantiate(rbd2d, tiroPoint.position, tiroPoint.rotation);
            tiro.transform.Rotate(0 , 0, 0);
        }
        else if (player.localScale.x == -0.22f)
        {
            Rigidbody2D tiro = Instantiate(rbd2d, tiroPoint.position, tiroPoint.rotation);
            tiro.transform.Rotate(0, 180, 0);
        }
    }

    public void FimAtirar()
    {
        
        pl.NoShooting();
    }

    public void FimTiroPulo()
    {
       
        pl.NoShooting();
        
    }
}
