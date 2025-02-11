using UnityEngine;

public class MedicineKit : MonoBehaviour, IPoolConnector
{
    private Pool _pool;

    public void ConnectPool(Pool pool)
    {
        _pool = pool;
    }

    public void Selection()
    {
        _pool.Release(gameObject);
    }
}
