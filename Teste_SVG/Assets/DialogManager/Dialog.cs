﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialog
{
    // Start is called before the first frame update
    public string name;

    [TextArea(3, 11)]
    public string[] sentences; 
}
