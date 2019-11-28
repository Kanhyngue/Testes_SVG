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
        private Transform panelTransform;

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
    }

    void Resizer()
    {
        
        if(!resize)
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
        }
    }

    IEnumerator Desresizer()
    {
        yield return new WaitForSeconds(3);
        resize = true;
    }
}
