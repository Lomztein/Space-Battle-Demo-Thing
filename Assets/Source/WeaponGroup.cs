using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponGroup : MonoBehaviour, IWeapon
{
    public GameObject[] Weapons;
    private IWeapon[] _weapons;

    public bool Fire()
    {
        bool any = false;
        foreach (IWeapon weapon in _weapons)
        {
            if (weapon.Fire())
            {
                any = true;
            }
        }
        return any;
    }

    // Start is called before the first frame update
    void Start()
    {
        _weapons = Weapons.Select(x => x.GetComponent<IWeapon>()).ToArray();
    }

}
