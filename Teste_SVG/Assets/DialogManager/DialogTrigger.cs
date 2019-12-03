using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] dialog;


    public void TriggerDialog(int index)
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog[index]);
    }
}
