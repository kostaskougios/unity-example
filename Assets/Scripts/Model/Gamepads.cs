using UnityEngine.InputSystem;
using Utils;

namespace Model
{
    public static class Gamepads
    {
        public static Gamepad GamepadNamed(string name)
        {
            return Gamepad.all.Find(g => g.name==name);
        } 
    }
}