using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogText;

    private Queue<string> sentences;

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

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        //Debug.Log(sentence);
    }

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
