using System;
using UnityEngine;

namespace Projectiles
{
    public class BulletHittingObject : MonoBehaviour
    {
        public GameObject explosion;

        private void OnCollisionEnter(Collision other)
        {
            var p = Instantiate(explosion);
            var t = transform;
            p.transform.position = t.position;
            p.transform.rotation = t.rotation;
            Destroy(p, 2);
            Destroy(gameObject);
        }
    }
}