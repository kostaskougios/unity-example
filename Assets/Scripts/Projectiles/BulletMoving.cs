using UnityEngine;

namespace Projectiles
{
    public class BulletMoving : MonoBehaviour
    {
        public float speed = 10;
        public float destroyAfter = 2;

        void Update()
        {
            var dt = Time.deltaTime;
            transform.Translate(speed * dt, 0, 0);
        }

        void Start()
        {
            Destroy(gameObject, destroyAfter);
        }
    }
}