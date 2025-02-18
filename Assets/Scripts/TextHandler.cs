using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextHandler : MonoBehaviour
{
    [SerializeField] private Text _textView;
    [SerializeField] private string _textDefault;
    [SerializeField] private string _textSupplement;
    [SerializeField] private string _textNew;
    [SerializeField] private float _timeTransition;
    [SerializeField] private float _delay;

    private bool _richTextEnabled = true;

    private void Start()
    {
        _textView.text = _textDefault;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_textView.DOText(_textNew, _timeTransition).SetDelay(_delay));
        sequence.Append(_textView.DOText(_textSupplement, _timeTransition).SetRelative().SetDelay(_delay));
        sequence.Append(_textView.DOText(_textDefault, _timeTransition, _richTextEnabled, ScrambleMode.All));
    }
}
