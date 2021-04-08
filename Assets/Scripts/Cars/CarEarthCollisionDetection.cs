using Model;
using UnityEngine;

namespace Cars
{
    public class CarEarthCollisionDetection : MonoBehaviour
    {
        private bool touchingEarth=true;

        public bool TouchingEarth => touchingEarth;

        private void OnTriggerEnter(Collider c)
        {
        }

        private void OnTriggerStay(Collider other)
        {
        }

        private void OnTriggerExit(Collider c)
        {
        }
    }
}