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
        transform.Translate(1 * dt, speed * dt, 0);
        transform.Rotate(0, 0, rotateSpeed * dt);
    }
}
