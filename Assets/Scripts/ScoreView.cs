using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnEnable()
    {
        _scoreCounter.ChangedScore += ShowInfo;
    }

    private void OnDisable()
    {
        _scoreCounter.ChangedScore -= ShowInfo;
    }

    private void ShowInfo(float score)
    {
        _text.text = score.ToString();
    }
}
