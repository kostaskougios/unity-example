using UnityEngine;

namespace Camera
{
    /**
 * Add this on a camera to follow the followMe game object
 */
    public class CameraFollowMe : MonoBehaviour
    {
        public GameObject followMe;
        public float turnSpeed = 4.0f;

        private Vector3 offset;
        private Transform player;

        void Start()
        {
            player = followMe.transform;
            offset = new Vector3(12, 12, 12);
        }

        void LateUpdate()
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
            var position = player.position;
            transform.position = position + offset;
            transform.LookAt(position);
        }
    }
}