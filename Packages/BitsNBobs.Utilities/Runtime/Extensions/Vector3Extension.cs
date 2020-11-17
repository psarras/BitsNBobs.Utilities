using UnityEngine;

namespace BitsNBobs.Extensions
{
    public static class Vector3Extension
    {
        public static Vector3 Set(this Vector3 vector3, float? x = null, float? y = null, float? z = null)
        {
            var xx = x ?? vector3.x;
            var yy = y ?? vector3.z;
            var zz = z ?? vector3.z;
            return new Vector3(xx, yy, zz);
        }
    }
}