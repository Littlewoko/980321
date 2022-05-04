using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreUIBehaviour : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        ScoreManager.OnScoreChange += UpdateScore;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChange -= UpdateScore;
    }

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
