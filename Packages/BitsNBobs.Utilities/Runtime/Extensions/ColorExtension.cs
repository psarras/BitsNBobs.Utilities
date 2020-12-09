using UnityEngine;

namespace BitsNBobs.Extensions
{
    public static class ColorExtension
    {
        public static Color ToUnity(this System.Drawing.Color color)
        {
            return new Color(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
        }
    }
}