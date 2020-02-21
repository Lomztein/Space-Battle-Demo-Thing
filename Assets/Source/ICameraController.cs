using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICameraController
{
    Transform Target { get; }

    event Action<Transform> OnTargetSwitch;
}
