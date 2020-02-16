using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControllerInput : MonoBehaviour, ITargeter
{
    private IControllable _controllable;
    private ITargetProvider _targetProvider;

    public Transform Target;
    public float FireThreshold;
    public float FireRange;

    private Vector3 _prevTargetPos;
    public float ProjectileSpeed;

    public float RotMultiplier;
    private Vector3 _targetPosition;

    void Start()
    {
        _controllable = GetComponent<IControllable>();
        _targetProvider = GetComponent<ITargetProvider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Target == null)
        {
            Target = _targetProvider.GetTarget();
            if (Target != null)
            {
               _prevTargetPos = Target.position;
            }
        }
        else
        {
            float dist = Vector3.Distance(transform.position, Target.position);
            _targetPosition = Target.position + (Target.position - _prevTargetPos) * (dist / ProjectileSpeed / Time.fixedDeltaTime);
            Vector3 relative = transform.InverseTransformPoint(_targetPosition);
            _controllable.Forward(Mathf.Sign (relative.z), Time.fixedDeltaTime);

            float yAngle = Mathf.Rad2Deg * Mathf.Atan2(relative.z, relative.y) - 90;
            _controllable.Pitch(Mathf.Clamp(yAngle, -1, 1) * RotMultiplier, Time.deltaTime);

            float xAngle = Mathf.Rad2Deg * Mathf.Atan2(relative.x, relative.z);
            _controllable.Roll(Mathf.Clamp(xAngle, -1, 1) * RotMultiplier, Time.deltaTime);

            float angleToTarget = Vector3.Angle(transform.forward, _targetPosition - transform.position);
            if (angleToTarget < FireThreshold && dist < FireRange)
            {
                _controllable.Primary();
            }

            _prevTargetPos = Target.position;

            if (Random.Range (0, 1000) == 0)
            {
                Target = null;
            }
        }
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    private void OnDrawGizmos ()
    {
        Gizmos.DrawWireSphere(_targetPosition, 0.25f);
        Gizmos.DrawLine(transform.position, _targetPosition);
    }
}
