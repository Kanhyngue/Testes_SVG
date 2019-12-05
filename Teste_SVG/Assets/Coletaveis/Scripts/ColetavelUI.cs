using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetavelUI : MonoBehaviour
{
    public Text cachimboText;
    public Transform panel;
    public static bool activated = false;
    private float waitTime;
    public RectTransform panelTransform;
    private int cachimbosQuant;

    [SerializeField] private GameObject[] desbloqueios;

    void Start()
    {
        panelTransform.anchoredPosition = new Vector2(-170f, panelTransform.anchoredPosition.y);
        waitTime = 3f;
        //       anim = GetComponent<Animator>();
    }

    void LateUpdate()
    {
        waitTime -= Time.deltaTime;

        //Debug.Log(waitTime);
        if (activated)
        {
            cachimboText.text = cachimbosQuant + " / 16";
            SlideIn();
        }

        if (waitTime < 0 && !activated)
        {
            SlideOut();
        }


        cachimbosQuant = 0;

        for (int i = 0; i < DataSystem.cachimbos.Length; i++)
        {
            if (DataSystem.cachimbos[i])
            {
                cachimbosQuant++;
                DataSystem.cachimbosColetados = cachimbosQuant;
            }
        }

        if (cachimbosQuant == 2)
        {
            desbloqueios[0].SetActive(true);
        }


        if (cachimbosQuant == 4)
        {
            desbloqueios[1].SetActive(true);
        }


        if (cachimbosQuant == 6)
        {
            desbloqueios[2].SetActive(true);
        }


        if (cachimbosQuant == 8)
        {
            desbloqueios[3].SetActive(true);
        }


        if (cachimbosQuant == 10)
        {
            desbloqueios[4].SetActive(true);
        }


        if (cachimbosQuant == 12)
        {
            desbloqueios[5].SetActive(true);
        }


        if (cachimbosQuant == 16)
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
            panelTransform.anchoredPosition += Vector2.right * 5;
            waitTime = 3;
        }
        else
        {
            activated = false;
        }
    }

    void SlideOut()
    {
        if (panelTransform.anchoredPosition.x >= -170)
        {
            panelTransform.anchoredPosition -= Vector2.right * 5;
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