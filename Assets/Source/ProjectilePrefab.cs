using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePrefab : MonoBehaviour, IProjectilePrefab
{
    public GameObject Projectile;

    public int Amount;
    public float Deviation;
    public float Speed;
    public float Damage;

    public event Action<GameObject> OnProjectileSpawned;

    public void Fire(Vector3 position, Quaternion rotation)
    {
        for (int i = 0; i < Amount; i++)
        {
            Vector3 deviation = new Vector3(UnityEngine.Random.Range(-Deviation, Deviation), UnityEngine.Random.Range(-Deviation, Deviation));
            Vector3 direction = rotation * new Vector3(Mathf.Sin(Mathf.Deg2Rad * deviation.x), Mathf.Sin(Mathf.Deg2Rad * deviation.y), 1);

            GameObject obj = Instantiate(Projectile, position, rotation);
            Projectile projectile = obj.GetComponent<Projectile>();

            projectile.Direction = direction;
            projectile.Speed = Speed;
            projectile.Damage = Damage;

            OnProjectileSpawned?.Invoke(obj);
        }
    }
}
