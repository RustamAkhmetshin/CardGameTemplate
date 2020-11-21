using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tweener : MonoBehaviour, ITween
{
    private const float TWEEN_TIME = 1f;

    public void TweenInt(int from, int to, Action<int> everyStepCallback, Action finalCallback)
    {
        StartCoroutine(TweenIntCoroutine(from, to, everyStepCallback, finalCallback));
    }
    
    public void TweenRotation(Transform transformToMove, Quaternion to)
    {
        StartCoroutine(TweenRotationCoroutine(transformToMove, to));
    }

    private IEnumerator TweenIntCoroutine(int from, int to, Action<int> everyStepCallback, Action finalCallback)
    {
        int delta = Mathf.Abs(from - to);
        int step = (from > to) ? -1 : 1;

        for (int i = 0; i < delta; i++)
        {
            from += step;
            everyStepCallback(from);
            yield return new WaitForSeconds(TWEEN_TIME / delta);
        }

        finalCallback();
    }
    
    
    private IEnumerator TweenRotationCoroutine(Transform transformToMove, Quaternion to)
    {
        Quaternion from = transformToMove.rotation;
        for(var t = 0f; t < 1; t += Time.deltaTime/TWEEN_TIME)
        {
            transformToMove.rotation = Quaternion.Lerp(from, to, Mathf.SmoothStep(0.0f, 1.0f, t));
            yield return null;
        }
        transformToMove.rotation = to;
    }
}