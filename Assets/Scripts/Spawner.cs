using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Pool _pool;
    [SerializeField] private float _timeSpawnMin = 3f;
    [SerializeField] private float _timeSpawnMax = 6f;
    [SerializeField] private Vector2 _positionMin;
    [SerializeField] private Vector2 _positionMax;

    private Coroutine _coroutine;
    private bool _canWork = true;

    private void Start()
    {
        Activate();
    }

    private void Activate()
    {
        if (_coroutine != null)
            StopCoroutine(Work());

        _coroutine = StartCoroutine(Work());
    }

    private IEnumerator Work()
    {
        while (_canWork)
        {
            GameObject objectPool = _pool.Get();

            if (objectPool != null)
            {
                objectPool.transform.position = new Vector2(Random.Range(_positionMin.x, _positionMax.x), Random.Range(_positionMin.y, _positionMax.y));

                yield return new WaitForSeconds(Random.Range(_timeSpawnMin, _timeSpawnMax));
            }
        }
    }
}
