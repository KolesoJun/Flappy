using System.Collections.Generic;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{
    [SerializeField] protected int CountObjects = 10;
    [SerializeField] protected GameObject[] Prefabs;

    protected Stack<GameObject> ObjectsInPool;

    public abstract GameObject Get();

    public void Release(GameObject objectPool)
    {
        ObjectsInPool.Push(objectPool);
        objectPool.gameObject.SetActive(false);
    }

    protected void Replenish()
    {
        if (ObjectsInPool.Count == 0)
            Create();
    }

    protected void Init()
    {
        ObjectsInPool = new Stack<GameObject>();

        for (int i = 0; i < CountObjects; i++)
            Create();
    }

    private void Create()
    {
        GameObject objectPool = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
        ObjectsInPool.Push(objectPool);
        objectPool.gameObject.SetActive(false);
    }
}
