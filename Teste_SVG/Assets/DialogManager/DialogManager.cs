using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;

    private Queue<string> sentences;
    private int contador = 0;
    private string sentence = "";
    private int rand;
    

    [SerializeField]
    private Animator animator;
    private int fonteNPC;



    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog _dialog, int source)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = _dialog.name;

        //Debug.Log("Conversando com: " + _dialog.name);

        sentences.Clear();

        
        
        foreach (string sentence in _dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        contador = 0;
        fonteNPC = source;
        Debug.Log("DialogManager");
        StopAllCoroutines();
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        //Debug.Log(fonteNPC);
        switch (fonteNPC)
        {
            case 0://sem fonte
                Debug.Log("Nenhuma fonte");
                break;

            case 1://Pajé
                //StopAllCoroutines();
                if (sentences.Count == 0 && contador == 0)
                {
                    EndDialog();
                    if (Paje_Controller.seletorFalaPaje == 0)
                    {
                        DataSystem.machadinha = true;
                        Paje_Controller.seletorFalaPaje++;
                    }
                    if (Paje_Controller.seletorFalaPaje % 2 == 0)
                        Paje_Controller.seletorFalaPaje++;
                    return;
                }
                switch (contador)
                {
                    case 0:
                        //StopAllCoroutines();
                        sentence = sentences.Dequeue();
                        StartCoroutine(TypeSentence(sentence));
                        contador = 1;
                        break;
                    case 1:
                        StopAllCoroutines();
                        dialogText.text = sentence;
                        contador = 0;
                        break;
                    case 2:
                        //StopAllCoroutines();
                        contador = 0;
                        break;
                    default:
                        break;
                }
                break;


            case 2://Pescador
                if (sentences.Count == 0 && contador == 0)
                {
                    EndDialog();                    
                    return;
                }

                switch (contador)
                {
                    case 0:
                        //StopAllCoroutines();
                        sentence = sentences.Dequeue();
                        StartCoroutine(TypeSentence(sentence));
                        contador = 1;
                        break;
                    case 1:
                        StopAllCoroutines();
                        dialogText.text = sentence;
                        contador = 0;
                        break;
                    case 2:
                        //StopAllCoroutines();
                        contador = 0;
                        break;
                    default:
                        break;
                }
                break;
            case 3://NPC
                if (sentences.Count == 0 && contador == 0)
                {
                    EndDialog();
                    return;
                }

                switch (contador)
                {
                    case 0:
                        //StopAllCoroutines();
                        sentence = sentences.Dequeue();
                        StartCoroutine(TypeSentence(sentence));
                        contador = 1;
                        break;
                    case 1:
                        StopAllCoroutines();
                        dialogText.text = sentence;
                        contador = 0;
                        break;
                    case 2:
                        //StopAllCoroutines();
                        contador = 0;
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
            
    
    }
    //string sentence = sentences.Dequeue();


    //Debug.Log(sentence);


    private void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        //Debug.Log("Fim da Conversa");
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

}
