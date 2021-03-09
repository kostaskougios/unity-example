using System;
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
        private BoxCollider earthCollider;
        private CarEarthCollisionDetection earthCollisionDetection;

        private void Start()
        {
            earthCollisionDetection = GetComponentInChildren<CarEarthCollisionDetection>();
            rb = GetComponent<Rigidbody>();
            earthCollider = GetComponent<BoxCollider>();
            movementListeners = movementListenerObjects.ToList()
                .Map(go => go.GetComponents<IMovementListener>().ToList())
                .Flatten();

            activeGamepad = GetComponent<ActiveGamepad>();
        }

        private float previousAcceleration;

        void Update()
        {
            var dt = Time.deltaTime;

            var gamepad = activeGamepad.GetGamepad();

            float turn = ReadSteeringX(gamepad)  * dt * 20000;
            float acceleration = (gamepad?.leftStick.ReadValue().y ?? 0) * dt * 16000;

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
            if(leftStickX!=0) return leftStickX;
            return gamepad.dpad.x.ReadValue();
        }

        private void FixCarFlipped()
        {
            var gamepad = activeGamepad.GetGamepad();
            if (gamepad.yButton.wasPressedThisFrame)
                transform.rotation = new Quaternion();
        }
    }
}