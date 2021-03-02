using UnityEngine;

namespace Camera
{
    /**
 * Add this on a camera to follow the followMe game object
 */
    public class CameraFollowMe : MonoBehaviour
    {
        [SerializeField] private GameObject followMe;

        private float i = 0;
        void Update()
        {
            var position = followMe.transform.position;
            i += 0.2f;
            transform.position = new Vector3(position.x + 20, position.y + 10, position.z + 15 );
        }
    }
}