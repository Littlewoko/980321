using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject highScore;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void HighScore()
    {
        mainMenu.SetActive(false);
        highScore.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        highScore.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
