using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreen;
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        DataSystem.health = 5;
        SceneManager.LoadScene("Menu");
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        DataSystem.health = 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if(Player.gameOver)
        {
            StartCoroutine(ActivateDeathScreen());
        }
    }

    IEnumerator ActivateDeathScreen()
    {
        yield return new WaitForSeconds(4);
        deathScreen.SetActive(true);
        Time.timeScale = 0.0001f;
    }
}
