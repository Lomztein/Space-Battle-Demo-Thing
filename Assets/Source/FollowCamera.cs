using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Target;
    public Vector3 PositionOffset;
    public Vector3 LookOffset;

    public float RotSpeed;
    public float MoveSpeed;

    void FixedUpdate()
    {
        if (Target == null)
        {
            var ships = GameObject.FindGameObjectsWithTag("Ship");
            Target = ships[Random.Range(0, ships.Length)].transform;
        }

        Vector3 targetPos = GetMovePosition();
        Vector3 lookPos = GetLookPosition();

        Quaternion targetRot = Quaternion.LookRotation(lookPos - transform.position, Target.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, RotSpeed * Time.fixedDeltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPos, MoveSpeed * Time.fixedDeltaTime);
    }

    void OnDrawGizmos ()
    {
        Vector3 targetPos = GetMovePosition();
        Vector3 lookPos = GetLookPosition ();

        Gizmos.DrawSphere(targetPos, 0.5f);
        Gizmos.DrawWireSphere(lookPos, 0.25f);
        Gizmos.DrawLine(targetPos, lookPos);
    }

    Vector3 GetMovePosition () => Target.position + Target.rotation * PositionOffset;
    Vector3 GetLookPosition () => Target.position + Target.rotation * LookOffset;

}
