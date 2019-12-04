using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToScene : MonoBehaviour
{
    public static bool loadGame;

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

    IEnumerator LoadToNewGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadToExistingGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
