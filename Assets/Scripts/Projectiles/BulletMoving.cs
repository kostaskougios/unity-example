using UnityEngine;

namespace Projectiles
{
    public class BulletMoving : MonoBehaviour
    {
        public float initialForce = 4000;
        public float destroyAfter = 4;

        void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.AddRelativeForce(0, 0, initialForce);
            Destroy(gameObject, destroyAfter);
        }
    }
}