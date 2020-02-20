using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float Firerate { get; }
    float Damage { get; }
    float Range { get; }

    bool CanFire();

    bool Fire();
}
