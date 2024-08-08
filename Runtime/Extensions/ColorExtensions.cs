using UnityEngine;

namespace ASP.Extensions
{
    public static class ColorExtensions
    {
        public static void SetAlpha(this Color color, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            Color newColor = color;
            newColor.a = alpha;
            color = newColor;
        }

        public static void SetAlpha(this Color[] colors, float alpha)
        {
            Color newColor;
            alpha = Mathf.Clamp01(alpha);

            for (int i = 0; i < colors.Length; i++)
            {
                newColor = colors[i];
                newColor.a = alpha;
                colors[i] = newColor;
            }
        }
    }
}
