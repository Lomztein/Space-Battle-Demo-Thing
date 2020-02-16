using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectilePrefab
{
    void Fire(Vector3 position, Quaternion rotation);

    event Action<GameObject> OnProjectileSpawned;
}
