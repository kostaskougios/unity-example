using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float destroyAfter = 2;

    private void Update()
    {
        var dt = Time.deltaTime;
        transform.Translate(speed * dt, 0, 0);
    }

    private void Start()
    {
        Destroy(gameObject, destroyAfter);
    }
}