﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class SplashToMenu : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            Debug.Log("acabou");
            EditorSceneManager.LoadScene("Menu");
        }
    }

 

}