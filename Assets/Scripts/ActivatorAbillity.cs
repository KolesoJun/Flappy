using UnityEngine;

public class ActivatorAbillity : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.ActivateShoot();
    }
}
