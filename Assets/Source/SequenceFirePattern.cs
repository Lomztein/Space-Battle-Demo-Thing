using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceFirePattern : MonoBehaviour, IFirePattern
{
    public float SequenceTime;

    public void Fire(int muzzles, Action<int> callback)
    {
        StartCoroutine(SequenceFire(muzzles, callback));
    }

    private IEnumerator SequenceFire (int muzzles, Action<int> callback)
    {
        for (int i = 0; i < muzzles; i++)
        {
            callback(i);
            yield return new WaitForSeconds(SequenceTime);
        }
    }
}
