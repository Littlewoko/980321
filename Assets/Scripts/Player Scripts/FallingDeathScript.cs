using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingDeathScript : MonoBehaviour
{
    private Transform tr;
    private Camera mainCamera;

    private Vector2 cameraMax = new Vector2();
    private Vector2 cameraMin = new Vector2();
    private Vector3 pos;
    private GameDataManager gdm;
    private ScoreManager scoreManager;

    private void Awake()
    {
        tr = transform;
        mainCamera = Camera.main;
    }

    private void Start()
    {
        CalculateCameraBounds();
    }

    private void Update()
    {
        CheckPosition();
    }

    private void CheckPosition()
    {
        pos = tr.position;

        if (pos.x < cameraMin.x) Kill();
        if (pos.x > cameraMax.x) Kill();

        if (pos.y < cameraMin.y) Kill();
        if (pos.y > cameraMax.y) Kill();
    }

    private void CalculateCameraBounds()
    {
        cameraMax.x = mainCamera.transform.position.x
            + mainCamera.orthographicSize * mainCamera.aspect;
        cameraMin.x = mainCamera.transform.position.x
            - mainCamera.orthographicSize * mainCamera.aspect;

        cameraMax.y = mainCamera.transform.position.y
            + mainCamera.orthographicSize;
        cameraMin.y = mainCamera.transform.position.y
            - mainCamera.orthographicSize;
    }

    private void Kill()
    {
        gdm = GetComponent<GameDataManager>();
        scoreManager = GetComponent<ScoreManager>();

        if (scoreManager.getScore() > gdm.getHighScore())
        {
            gdm.setHighScore(scoreManager.getScore());
            gdm.writeFile();
        }

        SceneManager.LoadScene("EndMenu");
    }
}
