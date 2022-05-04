using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    [SerializeField] private Transform[] platforms;
    [SerializeField] private Transform objective;
    [SerializeField] private float heightFromPlatform;
    [SerializeField] private ScoreManager scoreManager;

    public static Action<int> OnScoreChange; 

    private int lastLocation = -1;
    private int newLocation;
    private Vector2 pos;

    private int numOfCollections;

    private void Start()
    {
        //if (platforms.Length == 0) return;
        //numOfCollections = -1;
        //MoveObjective();
    }

    public void MoveObjective()
    {
        newLocation = UnityEngine.Random.Range(0, platforms.Length);
        while (lastLocation == newLocation)
        {
            newLocation = UnityEngine.Random.Range(0, platforms.Length);
        }

        pos = platforms[newLocation].position;
        pos.y += heightFromPlatform;
        objective.position = pos;
        numOfCollections++;
        OnScoreChange?.Invoke(numOfCollections);
    }
}
