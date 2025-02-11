using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public event Action Died;
    public event Action Wounded;
    public event Action Treated;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Obstacle>(out _))
            Died?.Invoke();

        if (collision.gameObject.TryGetComponent<Enemy>(out _))
            Wounded.Invoke();

        if(collision.gameObject.TryGetComponent(out MedicineKit medicine))
        {
            medicine.Selection();
            Treated.Invoke();
        }
    }
}
