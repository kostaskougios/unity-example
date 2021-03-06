using UnityEngine;
using UnityEngine.InputSystem;

namespace Players
{
    public class ActiveGamepad : MonoBehaviour
    {
        private int gamepadNumber = 0;

        public void EnableGamepad(int gamepadNumber)
        {
            this.gamepadNumber = gamepadNumber;
        }

        public Gamepad GetGamepad()
        {
            return Gamepad.all[gamepadNumber];
        }

    }
}