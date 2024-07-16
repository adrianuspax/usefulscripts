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

        public static float Normalization(float x, float A, float B)
        {
            float a, b;
            a = 1f / (B - A);
            b = 1f / (B - A) * A;
            return (a * x) - b;
        }

        public static float ContinuosNormal(float speed)
        {
            float t;
            t = Time.fixedTime;
            return ((speed * t) % 1);
        }

        public static float PendularNormal(float frequence)
        {
            (float x, float y) A;
            (float x, float y) B;
            float x, a, b, y, t, c;
            float radianization, sin, rangeValue;

            t = Time.fixedTime;
            c = (frequence * t) % 1;
            A = (0f, 0f);
            B = (1f, Mathf.PI);
            a = (B.y - A.y) / (B.x - A.x);
            b = A.y - (((B.y - A.y) / (B.x - A.x)) * A.x);
            rangeValue = c;
            x = rangeValue;
            y = (a * x) - b;
            radianization = y;
            sin = Mathf.Sin(radianization);
            return sin;
        }
    }
}