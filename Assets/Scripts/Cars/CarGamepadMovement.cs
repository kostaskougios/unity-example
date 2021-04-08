using System.Collections.Generic;
using Model;
using Players;
using UnityEngine;
using UnityEngine.InputSystem;
using Lib;

namespace Cars
{
    public class CarGamepadMovement : MonoBehaviour
    {
        public GameObject[] movementListenerObjects;

        private Rigidbody rb;
        private IEnumerable<IMovementListener> movementListeners;
        private ActiveGamepad activeGamepad;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            movementListeners = movementListenerObjects
                .Map(go => go.GetComponents<IMovementListener>())
                .Flatten();

            activeGamepad = GetComponent<ActiveGamepad>();
        }

        private float previousAcceleration;

        void Update()
        {
            var dt = Time.deltaTime;

            var gamepad = activeGamepad.GetGamepad();

            float turn = ReadSteeringX(gamepad) * dt * 30000;
            float acceleration = ReadSteeringY(gamepad) * dt * 100000;

            if (acceleration != 0) rb.AddRelativeForce(0, 0, acceleration);
            if (turn != 0) rb.AddRelativeTorque(0, turn, 0);

            FixCarFlipped();

            movementListeners.InvokeListeners(acceleration, previousAcceleration);
            previousAcceleration = acceleration;
        }

        private float ReadSteeringX(Gamepad gamepad)
        {
            if (gamepad is null) return 0;
            var leftStickX = gamepad.leftStick.ReadValue().x;
            return leftStickX;
        }

        private float ReadSteeringY(Gamepad gamepad)
        {
            if (gamepad is null) return 0;
            var leftStickY = gamepad.leftStick.ReadValue().y;
            return leftStickY;
        }

        private void FixCarFlipped()
        {
            var gamepad = activeGamepad.GetGamepad();
            if (gamepad.yButton.wasPressedThisFrame)
                transform.rotation = new Quaternion();
        }
    }
}