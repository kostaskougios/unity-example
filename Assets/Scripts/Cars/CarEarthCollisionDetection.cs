using System;
using Model;
using UnityEngine;

namespace Cars
{
    public class CarEarthCollisionDetection : MonoBehaviour
    {
        private bool touchingEarth;

        public bool TouchingEarth => touchingEarth;

        private void OnTriggerEnter(Collider c)
        {
            if (Earth.isCollidedWithEarth(c.transform))
                touchingEarth = true;
        }

        private void OnTriggerStay(Collider other)
        {
            OnTriggerEnter(other);
        }

        private void OnTriggerExit(Collider c)
        {
            if (Earth.isCollidedWithEarth(c.transform))
                touchingEarth = false;
        }
    }
}