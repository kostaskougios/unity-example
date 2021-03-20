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
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, initialForce);
        }
    }
}