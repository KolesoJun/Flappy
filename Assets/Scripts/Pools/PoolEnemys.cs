using UnityEngine;

public class PoolEnemys: Pool
{
    private void Awake()
    {
        Init();
    }

    public override GameObject Get()
    {
        Replenish();
        GameObject objectPool = ObjectsInPool.Pop();
        objectPool.gameObject.SetActive(true);
        objectPool.GetComponent<Enemy>().ConnectPool(this);

        return objectPool;
    }
}
