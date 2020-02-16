using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    void Pitch(float amount, float deltaTime);

    void Yaw(float amount, float deltaTime);

    void Roll(float amount, float deltaTime);

    void Forward(float amount, float deltaTime);

    void Strafe(float amount, float deltaTime);

    void Primary();

    void Secondary();
}
