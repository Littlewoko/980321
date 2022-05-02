using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private ScoreManager scoreManager;
    private GameDataManager gdm;

    public void Kill()
    {
        gdm = GetComponent<GameDataManager>();
        scoreManager = GetComponent<ScoreManager>();

        if (scoreManager.getScore() > gdm.getHighScore())
        {
            gdm.setHighScore(scoreManager.getScore());
            gdm.writeFile();
        }

        SceneManager.LoadScene("EndMenu");
    }
}
