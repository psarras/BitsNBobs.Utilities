using System;

namespace BitsNBobs.Extensions
{
    public static class MathExtension
    {
        public static float ManhattanDist(float[] a, float[] b)
        {
            if (a.Length != b.Length)
                throw new Exception("Vectors need to be of the same length");
            var d = 0f;
            
            for (int i = 0; i < b.Length; i++)
            {
                d += b[i] - a[i];
            }

            return Math.Abs(d);
        }
    }
}