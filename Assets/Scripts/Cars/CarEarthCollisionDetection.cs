using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class CarEarthCollisionDetection : MonoBehaviour
{
    public bool touchingEarth;

    private void OnTriggerEnter(Collider c)
    {
        if (Earth.isCollidedWithEarth(c.transform) )
        {
            print("OnTriggerEnter: true");
            touchingEarth = true;
        }
    }

    private void OnTriggerExit(Collider c)
    {
        if (Earth.isCollidedWithEarth(c.transform))
        {
            print("OnTriggerEnter: false");
            touchingEarth = false;
        }
    }
}
