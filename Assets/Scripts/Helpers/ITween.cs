using System;
using UnityEngine;

public interface ITween
{ 
    void TweenInt(int from, int to, Action<int> everyStepCallback, Action finalCallback);
    void TweenRotation(Transform transformToMove, Quaternion to);
}