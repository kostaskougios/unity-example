using Players;
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
        private ActiveGamepad activeGamepad;

        // ReSharper disable Unity.PerformanceAnalysis
        public void Follow(GameObject followMe)
        {
            player = followMe.transform;
            activeGamepad = followMe.GetComponent<ActiveGamepad>();
            offset = new Vector3(12, 12, 12);
        }

        void LateUpdate()
        {
            if (player is { })
            {
                var dt = Time.deltaTime;
                var dx = activeGamepad.GetGamepad().rightStick.ReadValue().x * dt * 10;
                offset = Quaternion.AngleAxis(dx * turnSpeed, Vector3.up) * offset;
                var position = player.position;
                transform.position = position + offset;
                transform.LookAt(position);
            }
        }
    }
}