using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetavelUI : MonoBehaviour
{
    public Text cachimboText;
    public Transform panel;
    public static bool activated = false;

    private float sizeX;
    private bool resize = false;
    private float waitTime;
    public RectTransform panelTransform;


    [SerializeField] private GameObject[] desbloqueios;

    private Animator anim;

    void Start()
    {
        sizeX = 0.0f;
        //       anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        waitTime -= Time.deltaTime;

        //Debug.Log(waitTime);
        if (activated)
        {
            cachimboText.text = DataSystem.cachimbos + " / 16";
            SlideIn();
        }

        if (waitTime < 0 && !activated)
        {
            SlideOut();
        }

        if (DataSystem.cachimbos == 2)
        {
            desbloqueios[0].SetActive(true);
        }


        if (DataSystem.cachimbos == 4)
        {
            desbloqueios[1].SetActive(true);
        }


        if (DataSystem.cachimbos == 6)
        {
            desbloqueios[2].SetActive(true);
        }


        if (DataSystem.cachimbos == 8)
        {
            desbloqueios[3].SetActive(true);
        }


        if (DataSystem.cachimbos == 10)
        {
            desbloqueios[4].SetActive(true);
        }


        if (DataSystem.cachimbos == 12)
        {
            desbloqueios[5].SetActive(true);
        }


        if (DataSystem.cachimbos == 16)
        {
            desbloqueios[6].SetActive(true);
        }

    }


    void SlideIn()
    {
        //Debug.Log(panelTransform.anchoredPosition);
        if (panelTransform.anchoredPosition.x <= 0)
        {
            //Debug.Log("IfResizer");
            panelTransform.gameObject.SetActive(true);
            panelTransform.anchoredPosition += Vector2.right * 2;
            waitTime = 3;
        }
        else
        {
            activated = false;
        }
    }

        
    /*void Resizer()
    
    /* if(!resize)
     {
         panel.transform.localScale = new Vector2(Mathf.Clamp(sizeX, 0f, 1f), 1.0f);
         sizeX += 0.1f;
     }
     else
     {
         panel.transform.localScale = new Vector2(Mathf.Clamp(sizeX, 0f, 1f), 1.0f);
         sizeX -= 0.1f;
     }


     if(sizeX >= 1.0f)
     {
         StartCoroutine(Desresizer());
     }
     else if(sizeX <= 0.1f)
     {
         sizeX = 0.0f;
         resize = false;
         activated = false;
     }*/


    void SlideOut()
    {
        if (panelTransform.anchoredPosition.x >= -170)
        {
            panelTransform.anchoredPosition -= Vector2.right * 2;
        }else
        {
            panelTransform.gameObject.SetActive(false);
        }
    }


    /*IEnumerator Desresizer()
    {
        yield return new WaitForSeconds(3f);
        //panelTransform.gameObject.SetActive(false);Debug.Log(panelTransform.anchoredPosition);



    }*/


}