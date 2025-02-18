using UnityEngine;
using DG.Tweening;

public class ObjectChangeScale : MonoBehaviour
{
    [SerializeField] private Vector3 _newScale;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private int _countRep = -1;

    private void Start()
    {
        transform.DOScale(_newScale, _duration).SetLoops(_countRep, _loopType);
    }
}
