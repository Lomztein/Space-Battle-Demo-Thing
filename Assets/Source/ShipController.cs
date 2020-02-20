using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour, IControllable, IThruster
{
    public GameObject PrimaryWeapon;
    public IWeapon _primaryWeapon;

    public GameObject SecondaryWeapon;
    public IWeapon _secondaryWeapon;

    public float MaxSpeed;
    public float AccelerationRate;
    public float Speed { get; private set; }

    public float StrafeMaxSpeed;
    public float StrafeAccelerationRate;
    public float StrafeSpeed { get; private set; }

    public float TargetPitch { get; private set; }
    public float TargetYaw { get; private set; }
    public float TargetRoll { get; private set; }

    public float CurrentPitch { get; private set; }
    public float CurrentYaw { get; private set; }
    public float CurrentRoll { get; private set; }

    public float PitchLerpSpeed;
    public float YawLerpSpeed;
    public float RollLerpSpeed;

    public float PitchSpeed;
    public float YawSpeed;
    public float RollSpeed;

    public void Start ()
    {
        _primaryWeapon = PrimaryWeapon?.GetComponent<IWeapon>();
        _secondaryWeapon = SecondaryWeapon?.GetComponent<IWeapon>();
    }

    public void Forward(float amount, float deltaTime)
    {
        Speed += AccelerationRate * amount * deltaTime;
        Speed = Mathf.Clamp(Speed, 0f, MaxSpeed);
    }

    public void Pitch(float amount, float deltaTime)
    {
        TargetPitch = Mathf.Clamp (amount, -1, 1);
    }

    public void Primary()
    {
        if (_primaryWeapon != null)
        {
            _primaryWeapon.Fire();
        }
    }

    public void Roll(float amount, float deltaTime)
    {
        TargetRoll = Mathf.Clamp(amount, -1, 1);
    }

    private float AddClamp (float value, float amount)
    {
        value += amount;
        return Mathf.Clamp(value, -1, 1);
    }

    public void Secondary()
    {
        if (_secondaryWeapon != null)
        {
            _secondaryWeapon.Fire();
        }
    }

    public void Strafe(float amount, float deltaTime)
    {
        StrafeSpeed += StrafeAccelerationRate * amount * deltaTime;
        StrafeSpeed = Mathf.Clamp(StrafeSpeed, -StrafeMaxSpeed, StrafeMaxSpeed);
    }

    public void Yaw(float amount, float deltaTime)
    {
        TargetYaw = Mathf.Clamp(amount, -1f, 1f);
    }

    private void FixedUpdate ()
    {
        ApplyMovement(Time.fixedDeltaTime);
    }

    private void ApplyMovement (float deltaTime)
    {
        LerpMovement(deltaTime);
        RotateMovement(deltaTime);
        TranslateMovement(deltaTime);
    }

    private void LerpMovement (float deltaTime)
    {
        CurrentPitch = Mathf.Lerp(CurrentPitch, TargetPitch, PitchLerpSpeed * deltaTime);
        CurrentYaw = Mathf.Lerp(CurrentYaw, TargetYaw, YawLerpSpeed * deltaTime);
        CurrentRoll = Mathf.Lerp(CurrentRoll, TargetRoll, RollLerpSpeed * deltaTime);
    }

    private void RotateMovement (float deltaTime)
    {
        Vector3 rotation = new Vector3(
            CurrentPitch * PitchSpeed,
            CurrentYaw * YawSpeed,
            CurrentRoll * RollSpeed
            );

        transform.Rotate(rotation * deltaTime);
    }

    private void TranslateMovement (float deltaTime)
    {
        transform.position += transform.forward * Speed * deltaTime;
    }

    public float GetThrust()
    {
        return Speed;
    }

    public float GetThrustFactor()
    {
        return Mathf.Abs (Speed / MaxSpeed);
    }
}
