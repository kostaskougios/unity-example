using UnityEngine;

namespace Model
{
    public static class Earth
    {
        public static bool isCollidedWithEarth(Transform t)
        {
            return t.parent?.transform.gameObject.name.Equals("Earth") ?? false;
        }
    }
}