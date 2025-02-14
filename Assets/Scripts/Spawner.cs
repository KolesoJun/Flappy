using System.Collections;
using UnityEngine;

public abstract class Spawner<T>: MonoBehaviour where T: MonoBehaviour
{
    [SerializeField] protected float TimeSpawnMin = 3f;
    [SerializeField] protected float TimeSpawnMax = 6f;
    [SerializeField] protected Vector2 PositionMin;
    [SerializeField] protected Vector2 PositionMax;

    protected Coroutine CoroutineSpawner;
    protected bool CanWork = true;

    public abstract void ReleaseInPool(T objectPool);

    protected abstract void Init();
    protected abstract void InitOject(T objectPool);

    protected void Activate(Pool<T> pool)
    {
        if (CoroutineSpawner != null)
            StopCoroutine(Work(pool));

        CoroutineSpawner = StartCoroutine(Work(pool));
    }

    private IEnumerator Work(Pool<T> pool)
    {
        while (CanWork)
        {
            T objectPool = pool.Get();

            if (objectPool != null)
            {
                InitOject(objectPool);
                objectPool.transform.position = new Vector2(Random.Range(PositionMin.x, PositionMax.x), Random.Range(PositionMin.y, PositionMax.y));

                yield return new WaitForSeconds(Random.Range(TimeSpawnMin, TimeSpawnMax));
            }
        }
    }
}
