using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponGroup : MonoBehaviour, IWeapon
{
    public GameObject[] Weapons;
    private IWeapon[] _weapons;
    private IFirePattern _firePattern;

    public float Firerate => _weapons.First().Firerate;

    public float Damage => _weapons.Sum(x => x.Damage);

    public float Range => _weapons.Max(x => x.Range);

    public bool CanFire() => (_weapons.FirstOrDefault ()?.CanFire()).GetValueOrDefault ();

    public bool Fire()
    {
        if (CanFire ())
        {
            _firePattern.Fire(_weapons.Length, _weapons.First ().Firerate, x => _weapons[x].Fire());
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _weapons = Weapons.Select(x => x.GetComponent<IWeapon>()).ToArray();

        _firePattern = GetComponent<IFirePattern>();
        if (_firePattern == null)
        {
            _firePattern = new AllFirePattern();
        }
    }

}
