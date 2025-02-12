using UnityEngine;

public class PoolProjectile : Pool
{
    private void Awake()
    {
        if (IsValidate<Projectile>())
            Init();
    }

    public override GameObject Get()
    {
        Replenish();
        GameObject objectPool = ObjectsInPool.Pop();
        objectPool.gameObject.SetActive(true);
        objectPool.GetComponent<Projectile>().ConnectPool(this);

        return objectPool;
    }
}
