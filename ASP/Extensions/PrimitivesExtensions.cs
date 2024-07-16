using UnityEngine;

namespace ASP.Extensions
{
    public static class PrimitivesExtensions
    {
        /// <summary>
        /// Converts a boolean into an integer (0 or 1)
        /// </summary>
        /// <param name="boolean">boolean value</param>
        /// <returns>return 0 to false or 1 to true</returns>
        public static int ToInt(this bool boolean)
        {
            return boolean ? 1 : 0;
        }
        /// <summary>
        /// Converts a integer number into an boolean (false or true)
        /// </summary>
        /// <param name="integer">integer value</param>
        /// <returns>
        /// If integer number is greater to 0, return true. <br/>
        /// If integer number is less or equal than 0, return false.
        /// </returns>
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
