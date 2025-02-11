using System;
using UnityEngine;

public class CarrierPlayer : CarrierGun
{
    [SerializeField] private PlayerInput _playerInput;

    private bool _isWorkBurst;

    public override event Action FiredSingle;
    public override event Action FiredBurst;
    public override event Action StopedFire;

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
            FiredSingle?.Invoke();
    }

    private void ShotBurst()
    {
        if (_isWorkBurst)
        {
            _isWorkBurst = false;
            StopedFire?.Invoke();
        }
        else
        {
            _isWorkBurst = true;
            FiredBurst?.Invoke();
        }
    }
}
