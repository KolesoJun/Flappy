using UnityEngine;

public class PlayerMoverBroken : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerInteract _interact;
    [SerializeField] private Player _player;
    [SerializeField] private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _interact.Wounded += ActivateFall;
        _playerInput.Rised += Rise;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void OnDisable()
    {
        _interact.Wounded -= ActivateFall;
        _playerInput.Rised -= Rise;
    }

    private void Rise()
    {
        if(_player.IsBroken)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Impulse);
        }
    }

    private void Rotate()
    {
        if (_player.IsBroken)
        {
            float targetAngle = Mathf.Clamp(_rigidbody.velocity.y * _rotationSpeed, _minRotationZ, _maxRotationZ);
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            _player.transform.rotation = Quaternion.Lerp(_player.transform.rotation, targetRotation, Time.deltaTime);
        }
    }

    public void ActivateFall()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    public void DeactivateFall()
    {
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        _player.transform.rotation = new Quaternion();       
    }
}
