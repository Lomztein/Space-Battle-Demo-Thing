using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour, ICameraController
{
    public Transform Target { get; private set; }
    public Vector3 PositionOffset;
    public Vector3 LookOffset;

    public float RotSpeed;
    public float MoveSpeed;

    public event Action<Transform> OnTargetSwitch;

    void FixedUpdate()
    {
        if (Target == null)
        {
            var ships = GameObject.FindGameObjectsWithTag("Ship");
            SetTarget (ships[UnityEngine.Random.Range(0, ships.Length)].transform);
        }
        else
        {
            Vector3 targetPos = GetMovePosition();
            Vector3 lookPos = GetLookPosition();

            Quaternion targetRot = Quaternion.LookRotation(lookPos - transform.position, Target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.fixedDeltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos, MoveSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetTarget (Transform target)
    {
        Target = target;
        OnTargetSwitch?.Invoke(Target);
    }

    void OnDrawGizmos()
    {
        if (Target != null)
        {
            Vector3 targetPos = GetMovePosition();
            Vector3 lookPos = GetLookPosition();

            Gizmos.DrawSphere(targetPos, 0.5f);
            Gizmos.DrawWireSphere(lookPos, 0.25f);
            Gizmos.DrawLine(targetPos, lookPos);
        }
    }

    Vector3 GetMovePosition () => Target.position + Target.rotation * PositionOffset;
    Vector3 GetLookPosition () => Target.position + Target.rotation * LookOffset;

}
