using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInteract))]
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerMoverBroken _moverBroken;
    [SerializeField] private Rigidbody2D _rigidbody;

    [field: SerializeField] public Gun Gun { get; private set; }
    public bool IsBroken { get; private set; }

    private PlayerInteract _interact;

    private void Awake()
    {
        _interact = GetComponent<PlayerInteract>();
    }

    private void OnEnable()
    {
        _interact.Died += Death;
        _interact.Wounded += TakeDamage;
        _interact.Treated += Repair;
    }

    private void OnDisable()
    {
        _interact.Died -= Death;
        _interact.Wounded -= TakeDamage;
        _interact.Treated -= Repair;
    }

    public void Repair()
    {
        IsBroken = false;
        _moverBroken.DeactivateFall();
    }

    public void TakeDamage()
    {
        if(IsBroken == false)
        {
            IsBroken = true;
            _moverBroken.ActivateFall();
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("gg");
        Time.timeScale = 0f;
    }
}
