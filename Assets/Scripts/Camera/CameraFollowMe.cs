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
                var gp = activeGamepad.GetGamepad();
                var rsv = gp.rightStick.ReadValue();
                var dx = rsv.x * dt * 10;
                var dy = rsv.y * dt * 10;
                offset = Quaternion.AngleAxis(dx * turnSpeed, Vector3.up) * Quaternion.AngleAxis(dy * turnSpeed, Vector3.back) * offset;
                var position = player.position;
                var newPos = position + offset;
                // if (newPos.y < 50) newPos.y = 50;
                // if (newPos.y > 56) newPos.y = 56;
                print(newPos);
                transform.position = newPos;
                transform.LookAt(position);
            }
        }
    }
}