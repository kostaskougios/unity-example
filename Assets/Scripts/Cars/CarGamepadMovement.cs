using System.Collections.Generic;
using System.Linq;
using Model;
using Players;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Cars
{
    public class CarGamepadMovement : MonoBehaviour
    {
        public float maxSpeedMilesPerHour = 100;
        public float rotateSpeed = 20;

        public GameObject[] movementListenerObjects;

        private Rigidbody rb;
        private List<IMovementListener> movementListeners;
        private ActiveGamepad activeGamepad;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            movementListeners = movementListenerObjects.ToList()
                .Map(go => go.GetComponents<IMovementListener>().ToList())
                .Flatten();

            activeGamepad = GetComponent<ActiveGamepad>();
        }

        void Update()
        {
            var dt = Time.deltaTime;

            var gamepad = activeGamepad.GetGamepad();

            float horizontal = (gamepad?.leftStick.ReadValue().x ?? 0) * dt * rotateSpeed;
            float vertical = (gamepad?.leftStick.ReadValue().y ?? 0) * dt * maxSpeedMilesPerHour;

            var turn = horizontal * rotateSpeed * dt;

            if (vertical != 0) rb.AddRelativeForce(0, 0, vertical * 40);
            if (turn != 0) rb.AddRelativeTorque(0, turn * 80, 0);

            FixCarFlipped();
            // movementListeners.InvokeListeners(previousSpeed, currentSpeed);
        }

        private void FixCarFlipped()
        {
            var gamepad = activeGamepad.GetGamepad();
            if (gamepad.yButton.wasPressedThisFrame)
                transform.rotation = new Quaternion();
        }
    }
}