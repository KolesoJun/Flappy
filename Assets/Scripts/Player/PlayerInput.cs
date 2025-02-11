using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const KeyCode Force = KeyCode.Space;
    private const KeyCode Fire = KeyCode.Q;
    private const KeyCode FireBurst = KeyCode.E;
    private const string AxisHorizontal = "Horizontal";
    private const string AxisVertical = "Vertical";

    public event Action Rised;
    public event Action Fired;
    public event Action FiredBurst;
    public event Action<Vector2> Moved;

    private void Update()
    {
        if (Input.GetKeyDown(Force))
            Rised?.Invoke();

        Vector2 direction = new Vector2(Input.GetAxis(AxisHorizontal), Input.GetAxis(AxisVertical));
        Moved?.Invoke(direction);

        if (Input.GetKeyDown(Fire))
            Fired?.Invoke();

        if (Input.GetKeyDown(FireBurst))
            FiredBurst?.Invoke();
    }
}
