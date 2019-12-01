using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  ColetavelUI : MonoBehaviour
{
        public Text cachimboText;
        public Transform panel;
        public static bool activated;

        private float sizeX;
        private bool resize = false;
        public RectTransform panelTransform;

    [SerializeField] private GameObject[] desbloqueios;

    void Start()
    {
        sizeX = 0.0f;
    }

    void LateUpdate()
    {
        if(activated)
        {
            cachimboText.text = DataSystem.cachimbos + " / 16";
            Resizer();
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

    void Resizer()
    {

        Debug.Log("Resizer");
        if (!panelTransform.gameObject.activeInHierarchy)
        {
            Desresizer();
        }
        
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
    }

    IEnumerator Desresizer()
    {
        Debug.Log("IfResizer");
        panelTransform.gameObject.SetActive(true);
        panelTransform.Translate(Vector3.right * Time.deltaTime);
        yield return null;
    }
}
