using UnityEngine;
using DG.Tweening;

public class ObjectColorHandler : MonoBehaviour
{
    [SerializeField] private Color32 _colorNew;
    [SerializeField] private float _duration;
    [SerializeField] private LoopType _loopType;

    private int _countRep = -1;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        _meshRenderer.material.DOColor(_colorNew, _duration).SetLoops(_countRep, _loopType);
    }
}
