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
        public GameObject[] movementListenerObjects;

        private Rigidbody rb;
        private List<IMovementListener> movementListeners;
        private ActiveGamepad activeGamepad;
        private CarEarthCollisionDetection earthCollisionDetection;

        private void Start()
        {
            earthCollisionDetection = GetComponentInChildren<CarEarthCollisionDetection>();
            rb = GetComponent<Rigidbody>();
            movementListeners = movementListenerObjects.ToList()
                .Map(go => go.GetComponents<IMovementListener>().ToList())
                .Flatten().ToList();

            activeGamepad = GetComponent<ActiveGamepad>();
        }

        private float previousAcceleration;

        void Update()
        {
            var dt = Time.deltaTime;

            var gamepad = activeGamepad.GetGamepad();

            float turn = ReadSteeringX(gamepad) * dt * 14000;
            float acceleration = ReadSteeringY(gamepad) * dt * 16000;

            if (earthCollisionDetection.TouchingEarth)
            {
                if (acceleration != 0) rb.AddRelativeForce(0, 0, acceleration);
                if (turn != 0) rb.AddRelativeTorque(0, turn, 0);
            }

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