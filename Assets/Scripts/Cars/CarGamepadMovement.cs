using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Utils;

namespace Cars
{
    public class CarGamepadMovement : MonoBehaviour
    {
        public float maxSpeedMilesPerHour = 100;
        public float rotateSpeed = 20;

        [FormerlySerializedAs("movementListeners")]
        public GameObject[] movementListenerObjects;

        private float currentSpeed = 0;
        private List<IMovementListener> movementListeners;

        private void Start()
        {
            movementListeners = movementListenerObjects.ToList()
                .Map(go => go.GetComponents<IMovementListener>().ToList())
                .Flatten();
        }

        void Update()
        {
            var previousSpeed = currentSpeed;
            var dt = Time.deltaTime;
            var maxSpeed = maxSpeedMilesPerHour / 2000;

            var gamepad = Gamepad.current;

            float horizontal = (gamepad?.leftStick.ReadValue().x ?? 0) * dt * rotateSpeed;
            float vertical = (gamepad?.leftStick.ReadValue().y ?? 0) * dt * maxSpeedMilesPerHour;

            if (vertical != 0)
            {
                currentSpeed += dt * vertical;
            }
            else
            {
                if (currentSpeed > 0) currentSpeed -= dt;
                else if (currentSpeed < 0) currentSpeed += dt;
                if (Mathf.Abs(currentSpeed) < dt) currentSpeed = 0;
            }

            if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;
            else if (currentSpeed < -maxSpeed) currentSpeed = -maxSpeed;

            var turn = horizontal * rotateSpeed * dt;

            transform.Translate(0, currentSpeed, 0);
            transform.Rotate(0, 0, turn);

            movementListeners.InvokeListeners(previousSpeed,currentSpeed);
        }
    }
}