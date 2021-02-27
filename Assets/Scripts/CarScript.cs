using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    float maxSpeedMilesPerHour = 100;

    [SerializeField]
    float rotateSpeed = 20;

    float currentSpeed = 0;
    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float maxSpeed = maxSpeedMilesPerHour / 2000;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        print(vertical);
        if (vertical != 0) currentSpeed += dt * vertical;
        else if (Input.GetKey(KeyCode.W)) currentSpeed += dt;
        else if (Input.GetKey(KeyCode.S)) currentSpeed -= dt;
        else {
            if (currentSpeed > 0) currentSpeed -= dt; else if (currentSpeed < 0) currentSpeed += dt;
            if (Mathf.Abs(currentSpeed) < dt) currentSpeed = 0;
        }
        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
        if (currentSpeed < -maxSpeed) currentSpeed = -maxSpeed;

        float turn = 0;

        if (Input.GetKey(KeyCode.A)) turn = -rotateSpeed * dt;
        if (Input.GetKey(KeyCode.D)) turn = +rotateSpeed * dt;

        transform.Translate(0, currentSpeed, 0);
        transform.Rotate(0, 0, turn);
    }
}
