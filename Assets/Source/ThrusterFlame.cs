using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterFlame : MonoBehaviour
{
    public GameObject Thruster;
    private IThruster _thruster;

    public float SizeMultilplier;
    public float RandomVariance;

    private void Start()
    {
        _thruster = Thruster.GetComponent<IThruster>();
    }

    void FixedUpdate()
    {
        transform.localScale = Vector3.one + Vector3.forward * SizeMultilplier * _thruster.GetThrustFactor () * Random.Range(1f - RandomVariance, 1f + RandomVariance);
    }
}
