using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private List<GameObject> inactiveEnemies = new List<GameObject>();
    private int enemyToActivate;

    private void Awake()
    {
        inactiveEnemies.AddRange(enemies);
    }

    public void IncreaseDifficulty()
    {
        if (inactiveEnemies.Count == 0) return;

        enemyToActivate = Random.Range(0, inactiveEnemies.Count);
        inactiveEnemies[enemyToActivate].SetActive(true);
        inactiveEnemies.RemoveAt(enemyToActivate);
    }
}
