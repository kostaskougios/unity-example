using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    [SerializeField] float speed = 10;

    float activeTime = 0;
    void Update()
    {
        var dt = Time.deltaTime;
        transform.Translate( speed * dt, 0,0);
        activeTime += dt;
        if(activeTime>3) Destroy(gameObject);
    }
}
