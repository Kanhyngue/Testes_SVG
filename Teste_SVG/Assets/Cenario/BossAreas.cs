using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreas : MonoBehaviour
{
    public int Area; // 1 -> Floresta | 2 -> Cerrado | 3 -> Caverna
    public GameObject bossCamera, bossLimiter;
    public GameObject normalCamera, normalLimiter;
    public GameObject boss;
    public BoxCollider2D bossGate1, bossGate2;
    private bool bossDefeated;
    private bool inBattle;

    void OnTriggerEnter2(Collider2D col)
    {

        if(col.gameObject.CompareTag("Player") && !bossDefeated && !inBattle)
        {
            bossCamera.SetActive(true);
            bossLimiter.SetActive(true);
            boss.SetActive(true);
            bossGate1.enabled = true;
            bossGate2.enabled = true;
            inBattle = true;
        }
    }

    void Update()
    {
        if(bossDefeated)
        {
            bossCamera.SetActive(false);
            bossLimiter.SetActive(false);
            boss.SetActive(false);

            normalCamera.SetActive(true);
            normalLimiter.SetActive(true);

            bossGate1.enabled = false;
            bossGate2.enabled = false;
            inBattle = false;
        }

        switch(Area)
        {
            case 1:
                if(BossManager.florestaBossDefeated)
                {
                    bossDefeated = true;
                }
            break;
            case 2:
                if(BossManager.cerradoBossDefeated)
                {
                    bossDefeated = true;
                }
            break;
            case 3:
                if(BossManager.cavernaBossDefeated)
                {
                    bossDefeated = true;
                }
            break;
            default:
                // Do anything
            break;
        }
    }
}
