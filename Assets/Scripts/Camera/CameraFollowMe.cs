using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Add this on a camera to follow the followMe game object
 */
public class CameraFollowMe : MonoBehaviour
{
    [SerializeField] private GameObject followMe;

    void Update()
    {
        var position = followMe.transform.position;
        transform.position = new Vector3(position.x + 20, position.y + 10, position.z+15);
    }
}