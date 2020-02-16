using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour, IControllable
{
    public GameObject PrimaryWeapon;
    public IWeapon _primaryWeapon;

    public GameObject SecondaryWeapon;
    public IWeapon _secondaryWeapon;

    public float MaxSpeed;
    public float AccelerationRate;
    private float _speed;

    public float TurnRate;
    public float RollRate;

    public void Start ()
    {
        _primaryWeapon = PrimaryWeapon?.GetComponent<IWeapon>();
        _secondaryWeapon = SecondaryWeapon?.GetComponent<IWeapon>();
    }

    public void Forward(float amount, float deltaTime)
    {
        if (_speed > MaxSpeed)
        {
            _speed = MaxSpeed;
        }else if (_speed < -MaxSpeed)
        {
            _speed = -MaxSpeed;
        }
        else
        {
            _speed += AccelerationRate * amount * deltaTime;
        }
    }

    public void Pitch(float amount, float deltaTime)
    {
        transform.Rotate(new Vector3(amount * TurnRate * deltaTime, 0f));
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
        transform.Rotate(new Vector3(0f, amount * TurnRate * deltaTime));
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
    }

    public void Yaw(float amount, float deltaTime)
    {
        transform.Rotate(new Vector3(0f, 0f, amount * TurnRate * deltaTime));
    }

    private void FixedUpdate ()
    {
        transform.Translate(0f, 0f, _speed * Time.fixedDeltaTime);
    }
}
