using System;
using Camera;
using UnityEngine;

namespace Players
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;
        public UnityEngine.Camera playerCamera;

        private bool instantiated = false;
        private void Update()
        {
            if (!instantiated)
            {
                instantiated = true;

                var t = transform;
                var p = Instantiate(player, t.parent);
                p.transform.position = t.position;
                p.transform.rotation = t.rotation;

                var cameraFollowMe = playerCamera.GetComponent<CameraFollowMe>();
                cameraFollowMe.Follow(p);
            }
        }
    }
}