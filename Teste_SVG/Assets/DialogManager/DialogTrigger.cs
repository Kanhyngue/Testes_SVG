using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] dialogs;


    public void TriggerDialog(int index)
    {
        FindObjectOfType<DialogManager>().StartDialog(dialogs[index]);
    }
}
