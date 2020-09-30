using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty 
{
    static float secondsToMaxDiff = 60;

    public static float GetDiffPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
    }
}
