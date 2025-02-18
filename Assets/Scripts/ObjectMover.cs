using DG.Tweening;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.DOMove(transform.position + transform.right, _speed);
    }
}
