using UnityEngine;

public class PoolItems : Pool
{
    private void Awake()
    {
        if(IsValidate<MedicineKit>())
            Init();
    }

    public override GameObject Get()
    {
        Replenish();
        GameObject objectPool = ObjectsInPool.Pop();
        objectPool.gameObject.SetActive(true);
        objectPool.GetComponent<MedicineKit>().ConnectPool(this);

        return objectPool;
    }
}
