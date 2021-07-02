using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public void gameIsOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Game Over. You have quit!");
        Application.Quit();
    }
}
