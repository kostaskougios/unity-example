using Camera;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;
        public UnityEngine.Camera playerCameraPrefab;
        public int playerNo;

        private bool instantiated;

        private void Update()
        {
            var playerCount = Gamepad.all.Count;
            if (!instantiated && playerCount > playerNo)
            {
                instantiated = true;

                var t = transform;
                var p = Instantiate(player, t.parent);
                p.name = "Player " + playerNo;
                p.transform.position = t.position;
                p.transform.rotation = t.rotation;

                var playerCamera = Instantiate(playerCameraPrefab);
                var camerasWidth = 1f / playerCount;
                playerCamera.rect = new Rect(playerNo * camerasWidth, 0, camerasWidth, 1);
                var cameraFollowMe = playerCamera.GetComponent<CameraFollowMe>();
                cameraFollowMe.Follow(p);

                p.GetComponent<ActiveGamepad>().EnableGamepad(playerNo);
            }
        }
    }
}