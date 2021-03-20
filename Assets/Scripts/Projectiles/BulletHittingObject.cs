using UnityEngine;

namespace Projectiles
{
    public class BulletHittingObject : MonoBehaviour
    {
        public GameObject explosion;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip,transform.position);
            var p = Instantiate(explosion);
            var t = transform;
            p.transform.position = t.position;
            p.transform.rotation = t.rotation;
            Destroy(p, 2);
            Destroy(gameObject);
        }
    }
}