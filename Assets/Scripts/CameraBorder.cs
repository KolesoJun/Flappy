using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Player _player;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private float _errorRate = 0.5f;

    void Start()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;

        CalculateCameraBounds();
    }

    void Update()
    {
        RestrictPlayerPosition();
    }

    void CalculateCameraBounds()
    {
        float orthographicSize = _mainCamera.orthographicSize;
        float aspect = _mainCamera.aspect;

        _minX = _mainCamera.transform.position.x - orthographicSize * aspect + _errorRate;
        _maxX = _mainCamera.transform.position.x + orthographicSize * aspect - _errorRate;
        _minY = _mainCamera.transform.position.y - orthographicSize + _errorRate;
        _maxY = _mainCamera.transform.position.y + orthographicSize - _errorRate;
    }

    void RestrictPlayerPosition()
    {
        Vector3 position = _player.transform.position;

        position.x = Mathf.Clamp(position.x, _minX, _maxX);
        position.y = Mathf.Clamp(position.y, _minY, _maxY);

        _player.transform.position = position;
    }
}
