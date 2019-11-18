using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DisableContinue : MonoBehaviour
{
    private Button thisButton;
    public GameObject thisParticleEffect;
    public Text thisText;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        string path = Application.persistentDataPath + "/data.cag";
        if(File.Exists(path))
        {
            thisButton.interactable = true;
            thisParticleEffect.SetActive(true);
            thisText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            thisButton.interactable = false;
            thisParticleEffect.SetActive(false);
            thisText.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
    }
}
