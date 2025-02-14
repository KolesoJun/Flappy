using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public event Action<float> ChangedScore;

    public float Score { get; private set; }

    public void Add()
    {
        Score ++;
        ChangedScore?.Invoke(Score);
    }

    private void Reset()
    {
        Score = 0;
        ChangedScore?.Invoke(Score);
    }
}
