using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private string saveFile;
    private GameData gameData;

    public static Action<int> resetScore;

    private void Awake()
    {
        saveFile = Application.persistentDataPath + "/gamedata.json";
        
        gameData = new GameData();

        readFile();
    }

    public void readFile()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }

    public void writeFile()
    {
        string jsonString = JsonUtility.ToJson(gameData);

        File.WriteAllText(saveFile, jsonString);
    }

    public int getHighScore()
    {
        return gameData.highScore;
    }

    public void setHighScore(int score)
    {
        gameData.highScore = score;
    }

    public void resetHighScore(int score) 
    {
        gameData.highScore = score;
        writeFile();
        resetScore?.Invoke(score);
    }
}
