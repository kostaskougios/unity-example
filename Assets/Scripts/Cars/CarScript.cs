using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float maxSpeedMilesPerHour = 100;

    public float rotateSpeed = 20;

    private float currentSpeed = 0;

    void Update()
    {
        float dt = Time.deltaTime;
        float maxSpeed = maxSpeedMilesPerHour / 2000;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vertical != 0) currentSpeed += dt * vertical;
        else if (Input.GetKey(KeyCode.W)) currentSpeed += dt;
        else if (Input.GetKey(KeyCode.S)) currentSpeed -= dt;
        else
        {
            if (currentSpeed > 0) currentSpeed -= dt; else if (currentSpeed < 0) currentSpeed += dt;
            if (Mathf.Abs(currentSpeed) < dt) currentSpeed = 0;
        }
        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        else if (currentSpeed < -maxSpeed) currentSpeed = -maxSpeed;

        var turn = horizontal * rotateSpeed * dt;
        if (Input.GetKey(KeyCode.A)) turn = -rotateSpeed * dt;
        if (Input.GetKey(KeyCode.D)) turn = rotateSpeed * dt;

        transform.Translate(0, currentSpeed, 0);
        transform.Rotate(0, 0, turn);
    }
}
