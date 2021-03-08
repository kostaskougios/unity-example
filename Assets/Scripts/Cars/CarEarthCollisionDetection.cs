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
            {
                print("OnTriggerEnter: Earth");
                touchingEarth = true;
            }
        }

        private void OnTriggerExit(Collider c)
        {
            if (Earth.isCollidedWithEarth(c.transform))
            {
                print("OnTriggerExit: Earth");
                touchingEarth = false;
            }
        }
    }
}