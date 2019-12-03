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

    [SerializeField]
    private Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialog _dialog)
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
        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
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
