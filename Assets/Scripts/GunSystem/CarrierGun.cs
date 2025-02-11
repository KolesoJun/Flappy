using System;
using UnityEngine;

public abstract class CarrierGun : MonoBehaviour
{
    public abstract event Action FiredSingle;
    public abstract event Action FiredBurst;
    public abstract event Action StopedFire;
}
