using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HPUIBehaviour : MonoBehaviour
{
    private TextMeshProUGUI hpText;

    private void OnEnable()
    {
        PlayerManager.OnHPChange += UpdateScore;
    }

    private void OnDisable()
    {
        PlayerManager.OnHPChange -= UpdateScore;
    }

    private void Awake()
    {
        hpText = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateScore(int score)
    {
        hpText.text = "HP: " + score.ToString();
    }
}
