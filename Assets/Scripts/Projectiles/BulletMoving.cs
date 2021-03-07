using System;
using UnityEngine;

namespace Projectiles
{
    public class BulletMoving : MonoBehaviour
    {
        float initialForce = 40000;
        float destroyAfter = 4;

        void Start()
        {
            Destroy(gameObject, destroyAfter);
        }

        private bool done;

        private void Update()
        {
            if (!done)
            {
                done = true;
                var rb = GetComponent<Rigidbody>();
                rb.AddRelativeForce(0, 0, initialForce);
            }
        }
    }
}