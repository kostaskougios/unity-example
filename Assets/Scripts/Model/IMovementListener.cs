using System.Collections.Generic;

namespace Model
{
    public interface IMovementListener
    {
        void StartMoving();
        void StopMoving();
    }

    public static class MovementListener
    {
        public static void InvokeListeners(
            this IEnumerable<IMovementListener> movementListeners, 
            float acceleration,
            float previousAcceleration
            )
        {
            if (previousAcceleration == 0 && acceleration != 0)
            {
                foreach (var listener in movementListeners)
                {
                    listener.StartMoving();
                }
            }
            else if (acceleration == 0 && previousAcceleration != 0)
            {
                foreach (var listener in movementListeners)
                {
                    listener.StopMoving();
                }
            }
        }
    }
}