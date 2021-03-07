using System.Collections.Generic;
using System.Linq;
using Model;
using Players;
using UnityEngine;
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

        private float previousAcceleration = 0;

        void Update()
        {
            var dt = Time.deltaTime;

            var gamepad = activeGamepad.GetGamepad();

            float horizontal = (gamepad?.leftStick.ReadValue().x ?? 0) * dt * rotateSpeed * 80;
            float acceleration = (gamepad?.leftStick.ReadValue().y ?? 0) * dt * maxSpeedMilesPerHour * 40;

            var turn = horizontal * rotateSpeed * dt;

            if (acceleration != 0) rb.AddRelativeForce(0, 0, acceleration);
            if (turn != 0) rb.AddRelativeTorque(0, turn, 0);

            FixCarFlipped();
            movementListeners.InvokeListeners(acceleration, previousAcceleration);

            previousAcceleration = acceleration;
        }

        private void FixCarFlipped()
        {
            var gamepad = activeGamepad.GetGamepad();
            if (gamepad.yButton.wasPressedThisFrame)
                transform.rotation = new Quaternion();
        }
    }
}