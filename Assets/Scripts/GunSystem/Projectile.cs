using UnityEngine;

public class Projectile : MonoBehaviour, IPoolConnector
{
    [field: SerializeField] public float Caliber { get; private set; }

    private Pool _pool;

    public void Stop()
    {
        _pool.Release(gameObject);
    }

    public void ConnectPool(Pool pool)
    {
        _pool = pool;
    }
}
