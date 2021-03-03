using UnityEngine;
using UnityEngine.InputSystem;

namespace Cars
{
    public class EngineSoundWhenMoving : MonoBehaviour
    {
        public AudioClip engineSound;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource=GetComponent<AudioSource>();
        }

        void Update()
        {
            var gamepad = Gamepad.current;
            float vertical = (gamepad?.leftStick.ReadValue().y ?? 0);
            if (vertical != 0)
            {
                audioSource.PlayOneShot(engineSound);
            }
        }
    
    }
}
