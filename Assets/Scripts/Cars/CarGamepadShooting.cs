using System;
using Players;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Cars
{
    public class CarGamepadShooting : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject shootPoint;

        private ActiveGamepad activeGamepad;

        private void Start()
        {
            activeGamepad = GetComponent<ActiveGamepad>();
        }

        void Update()
        {
            var gamepad = activeGamepad.GetGamepad();
            if (gamepad?.aButton.wasPressedThisFrame ?? false)
            {
                Instantiate(bullet,shootPoint.transform);
            }
        }
    }
}