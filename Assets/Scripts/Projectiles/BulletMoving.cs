using UnityEngine;

namespace Projectiles
{
    public class BulletMoving : MonoBehaviour
    {
        public float speed = 40;
        public float destroyAfter = 4;

        void Update()
        {
            var dt = Time.deltaTime;
            transform.Translate(0, 0, speed * dt);
        }

        void Start()
        {
            Destroy(gameObject, destroyAfter);
        }
    }
}