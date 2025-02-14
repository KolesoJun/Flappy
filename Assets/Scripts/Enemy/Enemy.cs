using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Gun _gun;

    private SpawnerEnemis _spawnerEnemis;
    private EnemyHandler _enemyHandler;
    private float _delay = 0.5f;
    private float _direction = -1f;

    public event Action Started;
    public event Action Released;

    private void Start()
    {
        StartCoroutine(DelayBeforeAttack());
    }

    public void ActivateShoot()
    {
        Started?.Invoke();
        _gun.StartFireBurst(transform.right * _direction);
    }

    public void TakeDamage()
    {
        _enemyHandler.TransmitCounter();
        Release();
    }

    public void Release()
    {
        Released?.Invoke();
        _gun.StopShoot();
        _spawnerEnemis.ReleaseInPool(this);
    }

    public void Init( SpawnerEnemis spawner, EnemyHandler enemyHandler)
    {
        _spawnerEnemis = spawner;
        _enemyHandler = enemyHandler;
    }

    private IEnumerator DelayBeforeAttack()
    {
        yield return new WaitForSeconds(_delay);

        Started?.Invoke();
    }
}
