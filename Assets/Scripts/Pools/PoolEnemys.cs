using UnityEngine;

public class PoolEnemys: Pool
{
    private void Awake()
    {
        if(IsValidate<Enemy>())
            Init();
    }

    public override GameObject Get()
    {
        Replenish();
        Enemy enemy = ObjectsInPool.Pop().GetComponent<Enemy>();
        enemy.gameObject.SetActive(true);
        enemy.ConnectPool(this);

        return enemy.gameObject;
    }
}
