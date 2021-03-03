using UnityEngine;
using UnityEngine.InputSystem;

namespace Cars
{
    public class CarGamepadShooting : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject shootPoint;

        void Update()
        {
            var gamepad = Gamepad.current;

            if (gamepad?.aButton.wasPressedThisFrame ?? false)
            {
                var b = Instantiate(bullet);
                b.transform.position = shootPoint.transform.position;
                b.transform.rotation = shootPoint.transform.rotation;
            }
        }
    }
}