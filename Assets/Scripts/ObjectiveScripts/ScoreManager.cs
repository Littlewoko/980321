using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

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
    }

    public void incrementScore(int amount)
    {
        score += amount;
    }

    public void decrementScore()
    {
        score--;
    }

    public void decrementScore(int amount)
    {
        score -= amount;
    }

}
