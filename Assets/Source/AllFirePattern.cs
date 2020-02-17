using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFirePattern : IFirePattern
{
    public void Fire(int muzzles, Action<int> callback)
    {
        for (int i = 0; i < muzzles; i++)
        {
            callback(i);
        }
    }
}
