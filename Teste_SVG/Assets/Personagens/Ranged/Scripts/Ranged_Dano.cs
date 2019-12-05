using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Dano : MonoBehaviour
{
    [SerializeField] Ranged_Tiro ranged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Dano de jogador
        if (collision.gameObject.CompareTag("PlayerHit") && !ranged.hit)
        {
            ranged.Dano();
        }

        if (collision.gameObject.CompareTag("Tiro") && !ranged.hit)
        {
            ranged.Dano();
        }
    }

    public void Tiro()
    {
        ranged.Atira();
    }

    public void Death()
    {
        ranged.Destroi();
    }
}
