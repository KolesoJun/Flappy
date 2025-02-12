using System.Collections.Generic;
using UnityEngine;

public abstract class Pool: MonoBehaviour
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
            Expend();
    }

    protected void Init()
    {
        ObjectsInPool = new Stack<GameObject>();

        for (int i = 0; i < CountObjects; i++)
            Expend();
    }

    protected bool IsValidate <T>()
    {
        bool isTrue = false;

        for (int i = 0; i < Prefabs.Length; i++)
            if (Prefabs[i].TryGetComponent<T>(out _))
                isTrue = true;

        return isTrue;
    }

    private void Expend()
    {
        GameObject objectPool = Instantiate(Prefabs[Random.Range(0, Prefabs.Length)]);
        ObjectsInPool.Push(objectPool);
        objectPool.gameObject.SetActive(false);
    }
}
