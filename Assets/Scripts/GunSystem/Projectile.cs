using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Gun _gunParrent;

    [field: SerializeField] public float Caliber { get; private set; }

    public void Stop()
    {
        _gunParrent.ReleaseInPool(this);
    }

    public void Init(Gun gun)
    {
        _gunParrent = gun;
    }
}
