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
            _controllable.Pitch(0f, Time.fixedDeltaTime);
            _controllable.Yaw(0f, Time.fixedDeltaTime);
            _controllable.Roll(0f, Time.fixedDeltaTime);

            Target = _targetProvider.GetTarget(transform.position, transform.forward);
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
            _controllable.Forward(Vector3.Dot (transform.forward, (_targetPosition - transform.position).normalized), Time.fixedDeltaTime);

            float yAngle = Mathf.Rad2Deg * Mathf.Atan2(relative.z, relative.y) - 90;
            _controllable.Pitch(Mathf.Clamp(yAngle, -1, 1) * RotMultiplier, Time.fixedDeltaTime);

            float xAngle = Mathf.Rad2Deg * Mathf.Atan2(relative.x, relative.z);
            _controllable.Yaw(Mathf.Clamp(xAngle, -1, 1) * RotMultiplier, Time.fixedDeltaTime);

            //_controllable.Roll(Mathf.Clamp(Mathf.DeltaAngle(transform.eulerAngles.z, Target.eulerAngles.z), -1, 1), Time.fixedDeltaTime);

            float angleToTarget = Vector3.Angle(transform.forward, _targetPosition - transform.position);
            if (angleToTarget < FireThreshold && dist < FireRange)
            {
                //Debug.Log(Mathf.DeltaAngle(transform.eulerAngles.z, Target.eulerAngles.z));
                _controllable.Roll(Mathf.DeltaAngle(transform.eulerAngles.z, Target.eulerAngles.z), Time.fixedDeltaTime);
                _controllable.Primary();
            }
            else
            {
                _controllable.Roll(0, Time.fixedDeltaTime);
            }

            _prevTargetPos = Target.position;

            if (Random.Range(0, 1000) == 0)
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
