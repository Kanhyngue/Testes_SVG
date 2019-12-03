using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcaPescador : MonoBehaviour
{

    private Player player;

    private DialogTrigger trigger;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("Player");
        player = obj.GetComponent<Player>();
        trigger = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //player.canMove = false;
            trigger.TriggerDialog(0, 2);
            StartCoroutine(player.MoveLeft());
        }
    }
}
