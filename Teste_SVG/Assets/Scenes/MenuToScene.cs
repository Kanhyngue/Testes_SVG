using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToScene : MonoBehaviour
{
    public static bool loadGame;
    public LoadScreenMenu loadScreen;



    public void NewGame()
    {
        loadGame = false;
        StartCoroutine(LoadToNewGame());
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

    public void Continue()
    {
        loadGame = true;
        StartCoroutine(LoadToExistingGame());
    }


    public void Creditos()
    {
        loadScreen.gameObject.SetActive(true);
        //loadScreen.FadeRotate();
        StartCoroutine(LoadCreditos());
    }

    IEnumerator LoadToNewGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while(!asyncLoad.isDone)
        {
            StartCoroutine(loadScreen.Rotate());
            yield return null;
        }
    }

    IEnumerator LoadToExistingGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while(!asyncLoad.isDone)
        {
            StartCoroutine(loadScreen.Rotate());
            yield return null;
        }
    }

    IEnumerator LoadCreditos()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Creditos");
        while (!asyncLoad.isDone)
        {
            StartCoroutine(loadScreen.Rotate());
            yield return null;
        }
    }

}
