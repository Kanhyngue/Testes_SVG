using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenMenu : MonoBehaviour
{
    [SerializeField]
    private Transform botton;



    // Start is called before the first frame update




    // Update is called once per frame
    public IEnumerator Rotate()
    {

        //.CrossFadeAlpha(1.0f, 2.0f, false);

        botton.transform.Rotate(Vector3.forward * Time.deltaTime * 10 * -1);
        yield return null;
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
