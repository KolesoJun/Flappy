using UnityEngine;
using DG.Tweening;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] private Vector3 _axis;
    [SerializeField] private float _angle;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private int _countRep = -1;

    private void Start()
    {
        transform.DORotate(_axis * _angle, _duration).SetLoops(_countRep, _loopType);
    }
}
