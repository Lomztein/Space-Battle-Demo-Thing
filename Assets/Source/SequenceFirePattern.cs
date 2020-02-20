using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceFirePattern : MonoBehaviour, IFirePattern
{
    public float Fraction;

    public void Fire(int muzzles, float firerate, Func<int, bool> callback)
    {
        StartCoroutine(SequenceFire(muzzles, firerate, callback));
    }

    private IEnumerator SequenceFire (int muzzles, float firerate, Func<int, bool> callback)
    {
        for (int i = 0; i < muzzles; i++)
        {
            while (!callback (i))
            {
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForSeconds(firerate * Fraction);
        }
    }
}
