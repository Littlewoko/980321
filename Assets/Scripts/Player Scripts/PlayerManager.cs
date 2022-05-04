using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private int hitPoints;

    public static Action<int> OnHPChange;

    private ScoreManager scoreManager;
    private GameDataManager gdm;

    private void Awake()
    {
        hitPoints = 1;
    }

    public void increaseHitPoints()
    {
        hitPoints++;
        OnHPChange?.Invoke(hitPoints);
    }

    public void decreaseHitPoints()
    {
        hitPoints--;
        OnHPChange?.Invoke(hitPoints);
    }

    public void hit()
    {
        if (hitPoints == 1)
        {
            Kill();
        }
        else
        {
            decreaseHitPoints();
        }
    }

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
