using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenRotate : MonoBehaviour
{
    [SerializeField] bool rotateR;
    [SerializeField] bool rotateL;
    [SerializeField] float rotationcounter;
    [SerializeField] float time;

    private bool isRotating = false;
    private float Rotation;

    private void Update()
    {
        if (rotateR == true)
        {
            Rotate90DegreesClockwise();
            rotateR = false;
        }
        if (rotateL == true)
        {
            Rotate90DegreesCounterClockwise();
            rotateL = false;
        }

    }

    // Rotate the GameObject 90 degrees around the Y axis over 3 seconds
    public void Rotate90DegreesClockwise()
    {
        if (!isRotating)
        {
            rotationcounter = rotationcounter + 90;
            isRotating = true;
            transform.DORotate(new Vector3(0f, rotationcounter, 0f), time)
                     .SetEase(Ease.InSine)
                     .OnComplete(() => isRotating = false);
        }
    }

    // Rotate the GameObject -90 degrees around the Y axis over 3 seconds
    public void Rotate90DegreesCounterClockwise()
    {
        if (!isRotating)
        {
            rotationcounter = rotationcounter - 90;
            isRotating = true;
            transform.DORotate(new Vector3(0f, rotationcounter, 0f), time)
                     .SetEase(Ease.InSine)
                     .OnComplete(() => isRotating = false);
        }
    }
}
