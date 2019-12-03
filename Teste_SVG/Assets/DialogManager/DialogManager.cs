using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;

    private Queue<string> sentences;
    private int contador = 0;
    private string sentence = "";

    [SerializeField]
    private Animator animator;


    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }


    public IntEvent NextSentenceEvent;

    private void Awake()
    {

        if (NextSentenceEvent == null)
            NextSentenceEvent = new IntEvent();
    }

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
        DisplayNextSentence(source);
    }


    public void DisplayNextSentence(int source)
    {
        Debug.Log(source);
        switch (source)
        {
            case 0://Pop Up
                Debug.Log("Fonte foi pop up");
                break;

            case 1://Pajé
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

                if (contador == 0)
                {
                    dialogText.text = "";
                    sentence = sentences.Dequeue();
                    contador++;
                }
                else if (contador == 1)
                {
                    StartCoroutine(TypeSentence(sentence));
                    contador++;
                }
                else if (contador == 2)
                {
                    StopAllCoroutines();
                    dialogText.text = sentence;
                    contador = 0;
                }
                break;
            case 2://Pescador

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
