using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{

    static float SecToMaxDiff = 60;
    
    private static float _timer = 0;

    private void OnEnable()
    {
        StartCoroutine("Timer");
    }
    private void OnDisable()
    {
        _timer = 0;
        StopCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while (true) {
            _timer += 5;
            yield return new WaitForSeconds(5f);
        }
    }
    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01( _timer/ SecToMaxDiff);
    }
    public static void SetDifficulty(float SecToMax = 60)
    {
        SecToMaxDiff = SecToMax;
    }
}
