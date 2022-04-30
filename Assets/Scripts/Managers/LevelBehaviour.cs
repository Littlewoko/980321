using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] platforms;

    public void activateLevel()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetActive(true);
        }
    }
}
