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
            p.transform.position = transform.position;
            p.transform.rotation = transform.rotation;
            Destroy(p, 2);
            Destroy(gameObject);
        }
    }
}