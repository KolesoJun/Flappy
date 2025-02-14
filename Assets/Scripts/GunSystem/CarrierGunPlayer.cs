using UnityEngine;

public class CarrierGunPlayer : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Gun _gun;

    private bool _isWorkBurst;

    private void OnEnable()
    {
        _playerInput.Fired += Shot;
        _playerInput.FiredBurst += ShotBurst;
    }

    private void OnDisable()
    {
        _playerInput.Fired -= Shot;
        _playerInput.FiredBurst -= ShotBurst;
    }

    private void Shot()
    {
        if (_isWorkBurst == false)
            _gun.Shot(transform.right);
    }

    private void ShotBurst()
    {
        if (_isWorkBurst)
        {
            _isWorkBurst = false;
            _gun.StopShoot();
        }
        else
        {
            _isWorkBurst = true;
            _gun.StartFireBurst(transform.right);
        }
    }
}
