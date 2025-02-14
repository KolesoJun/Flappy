using UnityEngine;
using System.Collections.Generic;

public class Pool<T> where T: MonoBehaviour
{
    private Stack<T> _objectsInPool;
    private int _countObjects = 10;
    private T _prefab;

    public int CountObjects => _countObjects;

    public Pool(T objectPool)
    {
        Init(objectPool);
    }

    public T Get() 
    {
        Replenish();
        T objectPool = _objectsInPool.Pop();
        objectPool.gameObject.SetActive(true);
        
        return objectPool;
    }

    public void Release(T objectPool)
    {
        _objectsInPool.Push(objectPool);
        objectPool.gameObject.SetActive(false);
    }

    private void Init(T prefab)
    {
        _objectsInPool = new Stack<T>();
        _prefab = prefab;

        for (int i = 0; i < CountObjects; i++)
            Expend();
    }

    private void Replenish()
    {
        if (_objectsInPool.Count == 0)
            Expend();
    }

    private void Expend()
    {
        T objectClone = MonoBehaviour.Instantiate(_prefab);
        _objectsInPool.Push(objectClone);
        objectClone.gameObject.SetActive(false);
    }
}
