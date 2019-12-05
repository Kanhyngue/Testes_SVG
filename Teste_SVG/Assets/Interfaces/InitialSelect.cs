using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialSelect : MonoBehaviour
{
    public Button initialButton;
    // Start is called before the first frame update
   public void Start()
    {
        initialButton.Select();
    }

}
