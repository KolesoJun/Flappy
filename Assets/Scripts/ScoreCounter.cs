using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;

    public event Action<float> ChangedScore;

    public float Score { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

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
