using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(GameDataManager))]
public class highScoreUIBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameDataManager gdm;

    private void OnEnable()
    {
        GameDataManager.resetScore += setScoreText;
    }

    private void OnDisable()
    {
        GameDataManager.resetScore -= setScoreText;
    }

    void Awake()
    {
        setScoreText(gdm.getHighScore());
    }

    private void setScoreText(int score)
    {
        highScoreText.text = "High Score: " + score;
    }
}
