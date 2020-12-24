using UnityEngine;

namespace BitsNBobs.Extensions
{
    public static class GradientExtension
    {
        public static Gradient GetHeatMap()
        {
            return new Gradient()
            {
                alphaKeys = new[]
                {
                    new GradientAlphaKey(1, 0),
                    new GradientAlphaKey(1, 0.25f),
                    new GradientAlphaKey(1, 0.5f),
                    new GradientAlphaKey(1, 0.75f),
                    new GradientAlphaKey(1, 1),
                },
                colorKeys = new[]
                {
                    new GradientColorKey(UnityEngine.Color.blue, 0),
                    new GradientColorKey(UnityEngine.Color.cyan, 0.25f),
                    new GradientColorKey(UnityEngine.Color.green, 0.5f),
                    new GradientColorKey(UnityEngine.Color.yellow, 0.75f),
                    new GradientColorKey(UnityEngine.Color.red, 1),
                }
            };
        }
    }
}