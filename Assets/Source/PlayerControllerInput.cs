using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInput : MonoBehaviour
{
    // Start is called before the first frame update
    private IControllable _controllable;

    void Start()
    {
        _controllable = GetComponent<IControllable>();
    }

    // Update is called once per frame
    void Update()
    {
        _controllable.Forward(Input.GetAxis("Vertical"), Time.deltaTime);
        _controllable.Strafe(Input.GetAxis("Horizontal"), Time.deltaTime);
        _controllable.Pitch(Input.GetAxis("Mouse Y"), Time.deltaTime);
        _controllable.Yaw(Input.GetAxis("Mouse X"), Time.deltaTime);

        if (Input.GetButton ("Fire1"))
        {
            _controllable.Primary();
        }

        if (Input.GetButton ("Fire2"))
        {
            _controllable.Secondary();
        }
    }
}
