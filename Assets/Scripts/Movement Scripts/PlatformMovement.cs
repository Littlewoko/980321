using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float yMoveDist;
    [SerializeField] private float xMoveDist;
    [SerializeField] private float movementTime;
    [SerializeField] private bool xMoveOnStartup;
    [SerializeField] private bool yMoveOnStartup;

    private Transform tr;
    private Sequence ySequence;
    private float yStart;
    private float yTop;
    private float yBottom;
    private float xStart;
    private float xTop;
    private float xBottom;
    private Sequence xSequence;

    public bool movingY { private set; get; }
    public bool movingX { private set; get; }

    private void Awake()
    {
        tr = transform;
        movingX = false;
        movingY = false;
    }

    private void Start()
    {
        if (xMoveOnStartup)
        {
            StartXMotion();
        }

        if (yMoveOnStartup)
        {
            StartYMotion();
        }
    }

    public void StartYMotion()
    {
        if (movingX) return;

        yStart = tr.localPosition.y;
        yTop = yStart + yMoveDist;
        yBottom = yStart - yMoveDist;

        movingY = true;
        tr.DOLocalMoveY(yTop, movementTime / 4f).SetEase(Ease.InOutCubic)
            .OnComplete(StartYSequence);
    }

    public void StartXMotion()
    {
        if (movingY) return;

        xStart = tr.localPosition.x;
        xTop = xStart + xMoveDist;
        xBottom = xStart - xMoveDist;

        movingX = true;
        tr.DOLocalMoveX(xTop, movementTime / 4f).SetEase(Ease.InOutCubic)
            .OnComplete(StartXSequence);
    }

    private void StartYSequence()
    {
        ySequence = DOTween.Sequence();

        ySequence.Append(tr.DOLocalMoveY(yBottom, movementTime / 2f))
            .SetEase(Ease.InOutCubic);
        

        ySequence.SetLoops(-1, LoopType.Yoyo);
    }

    private void StartXSequence()
    {
        xSequence = DOTween.Sequence();

        xSequence.Append(tr.DOLocalMoveX(xBottom, movementTime / 2f))
            .SetEase(Ease.InOutCubic);


        xSequence.SetLoops(-1, LoopType.Yoyo);
    }
}
