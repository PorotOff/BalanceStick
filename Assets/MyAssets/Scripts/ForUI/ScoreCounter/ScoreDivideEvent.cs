using System;
using UnityEngine;

public class ScoreDivideEvent : MonoBehaviour
{
    public static Action ScoreDivided;

    [SerializeField]
    private int divideScoreOn = 20;

    private void OnEnable() => ScoreCounter.PointAdded += CheckScoreDividing;
    private void OnDisable() => ScoreCounter.PointAdded -= CheckScoreDividing;

    private void CheckScoreDividing()
    {
        if (ScoreCounter.Score % divideScoreOn == 0) ScoreDivided?.Invoke();
    }
}
