using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public static Action<int> OnScoreChange;

    private void Awake()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }

    public void incrementScore()
    {
        score++;
        OnScoreChange?.Invoke(score);
    }

    public void incrementScore(int amount)
    {
        score += amount;
        OnScoreChange?.Invoke(score);
    }

    public void decrementScore()
    {
        score--;
        OnScoreChange?.Invoke(score);
    }

    public void decrementScore(int amount)
    {
        score -= amount;
        OnScoreChange?.Invoke(score);
    }

}
