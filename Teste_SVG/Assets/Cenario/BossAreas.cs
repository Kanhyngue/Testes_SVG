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
    [SerializeField]
    private bool bossDefeated = false;
    [SerializeField]
    private bool inBattle = false;
    public GameObject skyboxDay, skyboxTwilight, skyboxNight, skyboxMorning;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && !bossDefeated && !inBattle)
        {   
            bossCamera.SetActive(true);
            bossLimiter.SetActive(true);
            boss.SetActive(true);
            bossGate1.enabled = true;
            bossGate2.enabled = true;
            inBattle = true;
            skyboxDay.transform.localScale = new Vector2(1.25f, 1.25f);
            skyboxTwilight.transform.localScale = new Vector2(1.25f, 1.25f);
            skyboxNight.transform.localScale = new Vector2(1.25f, 1.25f);
            skyboxMorning.transform.localScale = new Vector2(1.25f, 1.25f);
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

            StartCoroutine(Wait());
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

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        skyboxDay.transform.localScale = new Vector2(1.0f, 1.0f);
        skyboxTwilight.transform.localScale = new Vector2(1.0f, 1.0f);
        skyboxNight.transform.localScale = new Vector2(1.0f, 1.0f);
        skyboxMorning.transform.localScale = new Vector2(1.0f, 1.0f);
    }
}
