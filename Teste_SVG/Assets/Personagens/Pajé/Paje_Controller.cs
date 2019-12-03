using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paje_Controller : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform ponto1, ponto2;

    [SerializeField]
    private float velocidade = 5;

    [SerializeField]
    private GameObject keyUpInterface; // Icone de Interação

    [SerializeField]
    private Animator boxAnimator;

    private DialogTrigger trigger;
    private Animator animator;
    private bool canMove, isFacingLeft;

    public static int seletorFalaPaje = 0;

    void Start()
    {
        isFacingLeft = true;
        canMove = true;
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("IsMoving", canMove);
        trigger = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boxAnimator.GetBool("IsOpen"))
        {
            animator.SetBool("IsTalking", false);
            if ((Vector2.Distance(transform.position, new Vector2(ponto1.position.x, transform.position.y)) > 0.1f) && canMove && isFacingLeft && !boxAnimator.GetBool("IsOpen"))
            {
                //Debug.Log("Mover ponto 1");
                MoverPara1(ponto1);
            }
            else if ((Vector2.Distance(transform.position, new Vector2(ponto2.position.x, transform.position.y)) > 0.1f) && canMove && !isFacingLeft && !boxAnimator.GetBool("IsOpen"))
            {
                //Debug.Log("Mover ponto 2");
                MoverPara1(ponto2);
            }
        }

    }

    IEnumerator WaitRandom()
    {
        //Debug.Log("Coroutine");
        yield return new WaitForSeconds(Random.Range(2f, 10f));
        Flip();
        canMove = true;
        animator.SetBool("IsMoving", canMove);
        //Debug.Log(canMove);
    }

    private void MoverPara1(Transform ponto)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(ponto.position.x, transform.position.y), velocidade * Time.deltaTime);

        //Debug.Log("canMove: " + canMove);
        //Debug.Log("isFacingLeft: " + isFacingLeft);
        //Debug.Log("Distance 1: " + (Vector2.Distance(transform.position, ponto.position)));

        if ((Vector2.Distance(transform.position, new Vector2(ponto.position.x, transform.position.y)) < 0.1f))
        {
            canMove = false;
            animator.SetBool("IsMoving", canMove);
            StartCoroutine(WaitRandom());
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingLeft = transform.localScale.x > 0;
    }

    private void OnTriggerStay2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            keyUpInterface.SetActive(true);
            if (Input.GetButtonDown("Interacao"))
            {
                canMove = false;
                animator.SetBool("IsMoving", canMove);
                animator.SetBool("IsTalking", true);
                trigger.TriggerDialog(0);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D entrada)
    {
        if (entrada.gameObject.CompareTag("Player"))
        {
            keyUpInterface.SetActive(false);
        }
    }
}
