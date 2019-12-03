using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] dialogs;
    private int rand;

    public void TriggerDialog(int index, int source)
    {

        if (source == 3)
        {
            //Debug.Log("TriggerDialog");
            switch (NPC_Controller.seletorFalaNPC)
            {
                case 0:
                    //Debug.Log("TriggerDialog" + NPC_Controller.seletorFalaNPC);
                    rand = Random.Range(0, 9);
                    FindObjectOfType<DialogManager>().StartDialog(dialogs[rand], 3);
                    break;
                case 1:
                    //Debug.Log("TriggerDialog" + NPC_Controller.seletorFalaNPC);
                    rand = Random.Range(9, 16);
                    FindObjectOfType<DialogManager>().StartDialog(dialogs[rand], 3);
                    break;
                case 2:
                    //Debug.Log("TriggerDialog" + NPC_Controller.seletorFalaNPC);
                    rand = Random.Range(16, 23);
                    FindObjectOfType<DialogManager>().StartDialog(dialogs[rand], 3);
                    break;
                default:
                    Debug.Log("TriggerDialog" + NPC_Controller.seletorFalaNPC);
                    break;
            }
        }
        else
        {
            FindObjectOfType<DialogManager>().StartDialog(dialogs[index], source);
        }
    }
}
