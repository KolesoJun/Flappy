using UnityEngine;

public class SpawnerItems : Spawner<Item>
{
    [SerializeField] private Item _prefab;

    private Pool<Item> _poolItem;

    private void Start()
    {
        Init();
    }

    public override void ReleaseInPool(Item objectPool)
    {
        _poolItem.Release(objectPool);
    }

    protected override void Init()
    {
        _poolItem = new Pool<Item>(_prefab);
        Activate(_poolItem);
    }

    protected override void InitOject(Item objectPool)
    {
        objectPool.Init(this);
    }
}
