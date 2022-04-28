using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLoopBehaviour : MonoBehaviour
{
    private Transform tr;
    private Camera mainCamera;

    private Vector2 cameraMax = new Vector2();
    private Vector2 cameraMin = new Vector2();
    private Vector3 pos;

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

        if (pos.x < cameraMin.x) pos.x = cameraMax.x;
        if (pos.x > cameraMax.x) pos.x = cameraMin.x;

        if (pos.y < cameraMin.y) pos.y = cameraMax.y;
        if (pos.y > cameraMax.y) pos.y = cameraMin.y;

        tr.position = pos;
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
}
