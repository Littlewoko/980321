using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float diffIncreaseRate;
    [SerializeField] private PlatformMovement[] platforms;

    private List<GameObject> inactiveEnemies = new List<GameObject>();
    private List<PlatformMovement> stationaryPlatforms = new List<PlatformMovement>();
    private int enemyToActivate;
    private int platformToMove;

    private float curChance;

    private void Awake()
    {
        inactiveEnemies.AddRange(enemies);
        stationaryPlatforms.AddRange(platforms);
    }

    private void Start()
    {
        curChance = 0.5f;
        InvokeRepeating("IncreaseDifficultyViaTime",
            diffIncreaseRate, diffIncreaseRate);
    }

    public void IncreaseDifficultyViaTime()
    {
        if (stationaryPlatforms.Count == 0) return;

        platformToMove = Random.Range(0, stationaryPlatforms.Count);

        if (stationaryPlatforms[platformToMove].movingX)
        {
            stationaryPlatforms[platformToMove].StartYMotion();
            stationaryPlatforms.RemoveAt(platformToMove);
            return;
        }

        if (stationaryPlatforms[platformToMove].movingY)
        {
            stationaryPlatforms[platformToMove].StartXMotion();
            stationaryPlatforms.RemoveAt(platformToMove);
            return;
        }

        if (Random.value >= curChance)
        {
            stationaryPlatforms[platformToMove].StartYMotion();
            curChance += 0.1f;
        }
        else
        {
            stationaryPlatforms[platformToMove].StartXMotion();
            curChance -= 0.1f;
        }
    }

    public void IncreaseDifficultyViaPorgression()
    {
        if (inactiveEnemies.Count == 0) return;

        enemyToActivate = Random.Range(0, inactiveEnemies.Count);
        inactiveEnemies[enemyToActivate].SetActive(true);
        inactiveEnemies.RemoveAt(enemyToActivate);
    }

    
}
