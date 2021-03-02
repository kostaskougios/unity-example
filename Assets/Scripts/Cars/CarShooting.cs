using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject shootPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var b = Instantiate(bullet);
            b.transform.position = shootPoint.transform.position;
            b.transform.rotation = shootPoint.transform.rotation;
        }

    }
}
