
using UnityEngine;

public class MoverEnvironment : MonoBehaviour
{
    private const float Direction = -1f;

    [SerializeField] private float _speed;
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(transform.right * Direction * _speed);
    }
}
