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
            this List<IMovementListener> movementListeners, 
            float previousSpeed,
            float currentSpeed)
        {
            if (previousSpeed == 0 && currentSpeed != 0)
            {
                foreach (var listener in movementListeners)
                {
                    listener.StartMoving();
                }
            }
            else if (currentSpeed == 0 && previousSpeed != 0)
            {
                foreach (var listener in movementListeners)
                {
                    listener.StopMoving();
                }
            }
        }
    }
}