using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthBarSlider;
    public Health Health;

    public GameObject Camera;
    private ICameraController _cameraController;

    private void Start()
    {
        _cameraController = Camera.GetComponent<ICameraController>();
        _cameraController.OnTargetSwitch += SwitchTarget;
    }

    private void SwitchTarget(Transform target)
    {
        Health = target.GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        if (Health != null)
        {
            HealthBarSlider.value = Health.CurrentHealth / Health.MaxHealth;
        }
    }
}
