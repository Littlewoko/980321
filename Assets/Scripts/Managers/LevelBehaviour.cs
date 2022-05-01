using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] platformsToActivate;
    [SerializeField] private GameObject[] platformsToDeactivate;

    public void activateLevel()
    {
        for (int i = 0; i < platformsToActivate.Length; i++)
        {
            platformsToActivate[i].SetActive(true);
        }
    }

    public void deactivateLevel()
    {
        for (int i = 0; i < platformsToDeactivate.Length; i++)
        {
            platformsToDeactivate[i].SetActive(false);
        }
    }
}
