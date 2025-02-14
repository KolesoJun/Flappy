using UnityEngine;

public class SpawnerEnemis : Spawner<Enemy>
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private EnemyHandler _enemyHandler;

    private Pool<Enemy> _poolEnemy;

    private void Start()
    {
        Init();
    }

    public override void ReleaseInPool(Enemy objectPool)
    {
        _poolEnemy.Release(objectPool);
    }

    protected override void Init()
    {
        _poolEnemy = new Pool<Enemy>(_prefab);
        Activate(_poolEnemy);
    }

    protected override void InitOject(Enemy objectPool)
    {
        objectPool.Init(this, _enemyHandler);
    }
}
