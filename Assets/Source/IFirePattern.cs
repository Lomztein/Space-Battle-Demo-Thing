using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFirePattern
{
    void Fire(int muzzles, Action<int> callback); 
}
