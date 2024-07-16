using UnityEngine;

namespace ASP
{
    /// <summary>
    /// Useful math calculations
    /// </summary>
    public class Calculation
    {
        /// <summary>
        /// In a Cartesian graph, returns the y value based on the x value entered in a range bounded on the X and Y axes: y = ax + b
        /// </summary>
        /// <param name="x">Value within the X-axis delimited range to return its Y-axis equivalence</param>
        /// <param name="A">Graph coordinates at point A: (xa)</param>
        /// <param name="B">Graph coordinates at point B: (xb)</param>
        /// <returns>Returns the value on the Cartesian line y over a range of ymin and ymax</returns>
        public static float Linear(float x, (float x, float y) A, (float x, float y) B)
        {
            float a, b, y;
            a = (B.y - A.y) / (B.x - A.x);
            b = A.y - (((B.y - A.y) / (B.x - A.x)) * A.x);
            y = (a * x) + b;
            return y;
        }
        /// <summary>
        /// On a Cartesian graph, returns the value of y based on the range of x-axis values in a quadratic function: y = ax² + bx + c
        /// </summary>
        /// <param name="x">Value within the X-axis delimited range to return its Y-axis equivalence</param>
        /// <param name="A">Graph coordinates at point A: (A.x, A.y)</param>
        /// <param name="B">Graph coordinates at point B: (B.x, B.y)</param>
        /// <returns>Returns the value of the quadratic function on the y-axis over a range of ymin and ymax</returns>
        public static float Quadratic(float x, (float x, float y) A, (float x, float y) B)
        {
            float a, b, c, y, k, x2;

            x2 = Mathf.Pow(x, 2);
            k = 1f / Mathf.Pow((B.x - A.x), 2);
            a = 4f * (A.y - B.y) * k;
            b = 4f * (B.y - A.y) * (B.x + A.x) * k;
            c = ((A.y - B.y) * Mathf.Pow((B.x + A.x), 2) * k) + B.y;
            y = (a * x2) + (b * x) + c;
            return y;
        }
        /// <summary>
        /// Normalization between two values
        /// </summary>
        /// <param name="value">Value to be normalized</param>
        /// <param name="min">Minimum limiting value</param>
        /// <param name="max">Maximum limiting value</param>
        /// <returns>Returns a value between 0 and 1</returns>
        public static float Normalization(float value, float min, float max)
        {
            value = Mathf.Clamp(value, min, max);
            float a = 1f / (max - min);
            float b = 1f / (max - min) * min;
            return (a * value) - b;
        }
    }
}