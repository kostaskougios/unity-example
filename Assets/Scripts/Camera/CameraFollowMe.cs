using UnityEngine;
using UnityEngine.InputSystem;

namespace Camera
{
    /**
 * Add this on a camera to follow the followMe game object
 */
    public class CameraFollowMe : MonoBehaviour
    {
        public float turnSpeed = 4.0f;

        private Vector3 offset;
        private Transform player;

        public void Follow(GameObject followMe)
        {
            player = followMe.transform;
            offset = new Vector3(12, 12, 12);
        }

        void LateUpdate()
        {
            if (player is { })
            {
                var gamepad = Gamepad.current;

                var dt = Time.deltaTime;
                var dx = gamepad?.rightStick.ReadValue().x * dt * 10 ?? 0f;
                offset = Quaternion.AngleAxis(dx * turnSpeed, Vector3.up) * offset;
                var position = player.position;
                transform.position = position + offset;
                transform.LookAt(position);
            }
        }
    }
}