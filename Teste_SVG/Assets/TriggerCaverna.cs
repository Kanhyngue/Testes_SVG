using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCaverna : MonoBehaviour
{
    [SerializeField]
    private Animator boxAnimator;

    private DialogTrigger dialog;
    private float timer;
    private void Start()
    {
        dialog = GetComponent<DialogTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && DataSystem.machadinha)
        {
            dialog.TriggerDialog(0, 4);
            timer = .2f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer -= Time.deltaTime;

        if (collision.gameObject.CompareTag("Player") && boxAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Closed") && timer < 0 &&  DataSystem.machadinha)
        {
            Destroy(gameObject);
        }
    }
}
