using System;
using UnityEngine;

public class CarrierEnemy : CarrierGun
{
    [SerializeField] private Enemy _enemy;

    public override event Action FiredSingle;
    public override event Action FiredBurst;
    public override event Action StopedFire;

    private void OnEnable()
    {
        _enemy.Started += StartFire;
        _enemy.Released += StopFire;
    }

    private void OnDisable()
    {
        _enemy.Started -= StartFire;
        _enemy.Released -= StopFire;
    }

    private void StartFire()
    {
        FiredBurst?.Invoke();
    }

    private void StopFire()
    {
        StopedFire?.Invoke();
    }
}
