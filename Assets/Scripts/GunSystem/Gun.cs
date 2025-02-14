using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private float _speedAttact = 1f;

    private Pool<Projectile> _poolAmmo;
    private Coroutine _coroutine;
    private bool _isWork;

    private void Awake()
    {
        _poolAmmo = new Pool<Projectile>(_prefab);
    }

    public void Shot(Vector2 muzzle)
    {
        Projectile projectile = _poolAmmo.Get();

        if (projectile != null)
        {
            projectile.Init(this);
            projectile.transform.position = transform.position;
            projectile.GetComponent<Rigidbody2D>().velocity = muzzle * projectile.Caliber;
        }
    }

    public void StartFireBurst(Vector2 muzzleDirection)
    {
        StopShoot();
        _coroutine = StartCoroutine(FireBurst(muzzleDirection));
    }

    public void StopShoot()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _isWork = false;
    }

    public void ReleaseInPool(Projectile projectile)
    {
        _poolAmmo.Release(projectile);
    }

    private IEnumerator FireBurst(Vector2 muzzleDirection)
    {
        WaitForSeconds wait = new WaitForSeconds(_speedAttact);
        _isWork = true;

        while (_isWork)
        {
            Shot(muzzleDirection);

            yield return wait;
        }
    }
}
