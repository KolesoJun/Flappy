using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private PoolProjectile _pool;
    [SerializeField] private CarrierGun _carrier;

    private Coroutine _coroutine;
    private float _cooldown = 1f;
    private bool _isWork;

    private void OnEnable()
    {
        _carrier.FiredSingle += Shot;
        _carrier.FiredBurst += StartFireBurst;
        _carrier.StopedFire += StopShoot;
    }

    private void OnDisable()
    {
        _carrier.FiredSingle -= Shot;
        _carrier.FiredBurst -= StartFireBurst;
        _carrier.StopedFire -= StopShoot;
    }

    private void Shot()
    {
        Projectile projectile = _pool.Get().GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.transform.position = transform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = _carrier.transform.right * projectile.Caliber * _direction;
        }
    }

    private void StartFireBurst()
    {
        StopShoot();
        _coroutine = StartCoroutine(FireBurst());
    }

    private IEnumerator FireBurst()
    {
        WaitForSeconds wait = new WaitForSeconds(_cooldown);
        _isWork = true;
        
        while (_isWork)
        {
            Shot();
            yield return wait;
        }
    }

    private void StopShoot()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _isWork = false;
    }
}
