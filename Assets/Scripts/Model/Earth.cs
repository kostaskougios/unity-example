using UnityEngine;

namespace Model
{
    public static class Earth
    {
        public static bool IsCollidedWithEarth(Transform t)
        {
            return t.parent?.transform.gameObject.name.Equals("Earth") ?? false;
        }
    }
}