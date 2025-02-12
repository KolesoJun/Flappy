using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IPoolConnector
{
    private Pool _pool;
    private float _delay = 0.5f;

    public event Action Started;
    public event Action Released;

    private void Start()
    {
        StartCoroutine(DelayBeforeAttack());
    }

    private IEnumerator DelayBeforeAttack()
    {
        yield return new WaitForSeconds(_delay);

        Started?.Invoke();
    }

    public void ActivateShoot()
    {
        Started?.Invoke();
    }

    public void TakeDamage()
    {
        Release();
    }

    public void Release()
    {
        Released?.Invoke();
        _pool.Release(gameObject);
    }

    public void ConnectPool(Pool pool)
    {
        _pool = pool;
    }
}
