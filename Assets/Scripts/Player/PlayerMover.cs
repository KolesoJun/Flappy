using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _playerInput.Moved += Move;
    }

    private void OnDisable()
    {
        _playerInput.Moved -= Move;
    }

    private void Move(Vector2 vector)
    {
        if(_player.IsBroken == false)
            _player.transform.position = Vector2.MoveTowards(_player.transform.position, CalculateDirection(vector), _speed * Time.deltaTime);
    }

    private Vector2 CalculateDirection(Vector2 vector)
    {
        return new Vector2(_player.transform.position.x + vector.x, _player.transform.position.y + vector.y);
    }
}
