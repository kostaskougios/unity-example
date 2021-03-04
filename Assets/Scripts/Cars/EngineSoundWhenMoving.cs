using UnityEngine;
using UnityEngine.InputSystem;

namespace Cars
{
    public class EngineSoundWhenMoving : MonoBehaviour
    {
        public AudioClip engineSound;

        private AudioSource audioSource;
        private CarGamepadMovement carGamepadMovement;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            carGamepadMovement = GetComponentInParent<CarGamepadMovement>();
        }

        void Update()
        {
            var gamepad = Gamepad.current;
            var vertical = gamepad?.leftStick.ReadValue().y ?? 0;
            if (vertical != 0)
            {
                audioSource.PlayOneShot(engineSound);
            }
        }
    }
}