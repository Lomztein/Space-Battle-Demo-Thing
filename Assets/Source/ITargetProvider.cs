using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetProvider
{
    Transform GetTarget(Vector3 center, Vector3 direction);
}
