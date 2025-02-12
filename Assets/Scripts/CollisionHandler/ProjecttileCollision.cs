using UnityEngine;

public class ProjecttileCollision : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage();
        }

        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage();
            ScoreCounter.Instance.Add();
        }

        _projectile.Stop();
    }
}
