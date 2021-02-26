using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    float rotateSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float forward = 0;

        if (Input.GetKey(KeyCode.W)) forward = speed * dt;
        if (Input.GetKey(KeyCode.S)) forward = -speed * dt;

        float turn = 0;

        if (Input.GetKey(KeyCode.A)) turn = -rotateSpeed * dt;
        if (Input.GetKey(KeyCode.D)) turn = +rotateSpeed * dt;

        transform.Translate(0, forward, 0);
        transform.Rotate(0, 0, turn);
    }
}
