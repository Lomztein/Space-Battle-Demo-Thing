using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public ProjectilePrefab ProjectilePrefab;
    public Transform Muzzle;
    public Flash Flash;

    public float ReloadTime;

    private bool _chambered = true;

    public void Chamber() => _chambered = true;

    private void Start ()
    {
        ProjectilePrefab.OnProjectileSpawned += OnProjectileSpawned;
    }

    private void OnProjectileSpawned(GameObject obj)
    {
        var factionObj = obj.GetComponent<FactionObject>();
        if (factionObj)
        {
            FactionMember member = GetComponentInParent<FactionMember>();
            factionObj.SetFaction(member.GetFaction ());
        }
    }

    public bool Fire ()
    {
        if (_chambered)
        {
            ProjectilePrefab.Fire(Muzzle.position, Muzzle.rotation);
            Flash.Animate();
            _chambered = false;
            Invoke("Chamber", ReloadTime);
            return true;
        }
        return false;
    }
}
