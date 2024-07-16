using UnityEngine;

namespace ASP.Extensions
{
    public static class PrimitivesExtensions
    {
        public static int ToInt(this bool boolean)
        {
            return boolean ? 1 : 0;
        }

        public static bool ToBool(this int integer)
        {
            if (integer < 0 || integer > 1)
            {
                Debug.LogWarning($"The value should be 0 (for false) or 1 (for true), " +
                    $"but the assigned value is {integer} and therefore the boolian default value is returned based in clamp!", default);
                integer = Mathf.Clamp(integer, 0, 1);
            }

            return integer == 1;
        }
    }
}

