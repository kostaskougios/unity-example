using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    float speed = 1;
    // Update is called once per frame
    void Update()
    {
        float dt=Time.deltaTime;
        transform.Translate(1* dt, speed * dt, 0);
    }
}
