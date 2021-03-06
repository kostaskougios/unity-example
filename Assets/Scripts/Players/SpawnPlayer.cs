using System;
using Camera;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;
        public UnityEngine.Camera playerCamera;
        public int playerNo = 0;

        private bool instantiated = false;

        private void Update()
        {
            if (!instantiated && Gamepad.all.Count >= playerNo)
            {
                instantiated = true;

                var t = transform;
                var p = Instantiate(player, t.parent);
                p.transform.position = t.position;
                p.transform.rotation = t.rotation;

                var cameraFollowMe = playerCamera.GetComponent<CameraFollowMe>();
                cameraFollowMe.Follow(p);
                
                p.GetComponent<ActiveGamepad>().EnableGamepad(playerNo);
            }
        }
    }
}