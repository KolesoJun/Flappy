using UnityEngine;

public class MedicineKit : Item
{
    private SpawnerItems _spawner;

    public override void Init(SpawnerItems spawner)
    {
        _spawner = spawner;
    }

    public void Selection()
    {
        _spawner.ReleaseInPool(this);
    }
}
