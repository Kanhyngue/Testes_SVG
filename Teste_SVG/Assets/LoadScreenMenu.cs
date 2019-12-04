using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject botton;

    [SerializeField]
    private GameObject logo;

    [SerializeField]
    private GameObject[] desativar;

    [SerializeField]
    private float velocidade;

    private Image imgBotton;

    private Image imgLogo;

    private Transform transformButton;

    // Start is called before the first frame update
    void Awake()
    {
        imgBotton = botton.GetComponent<Image>();
        transformButton = botton.GetComponent<Transform>();
        imgLogo = logo.GetComponent<Image>();

    }



    // Update is called once per frame
    private void Update()
    {

        //.CrossFadeAlpha(1.0f, 2.0f, false);

        transformButton.transform.Rotate(Vector3.forward * Time.deltaTime * velocidade * -1);
    }

    /*public void FadeRotate()
    {
        foreach(GameObject obj in desativar)
        {
            obj.SetActive(false);
        }
        transformButton.transform.Rotate(Vector3.forward * Time.deltaTime * velocidade * -1);
        imgBotton.CrossFadeAlpha(1, 2.0f, false);
    }*/


}
