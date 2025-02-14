using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    public void TransmitCounter()
    {
        _scoreCounter.Add();
    }
}
