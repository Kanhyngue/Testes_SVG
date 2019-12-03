using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] dialogs;


    public void TriggerDialog(int index, int source)
    {
        FindObjectOfType<DialogManager>().StartDialog(dialogs[index], source);
    }
}
