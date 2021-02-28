using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] float speed = 10;

    void Update()
    {
        float dt = Time.deltaTime;
        transform.Translate( speed * dt, 0,0);
    }
}
