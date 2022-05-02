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
     
    void Awake()
    {

        highScoreText.text = "Hgh Score: " + gdm.getHighScore().ToString();
    }
}
