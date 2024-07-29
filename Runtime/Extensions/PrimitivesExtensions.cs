using System;
using System.Linq;
using UnityEngine;

namespace ASP.Extensions
{
    public static class PrimitivesExtensions
    {
        /// <summary>
        /// Converts a boolean into an integer (0 or 1)
        /// </summary>
        /// <param name="bool">boolean value</param>
        /// <returns>return 0 to false or 1 to true</returns>
        public static int ToInt(this bool @bool)
        {
            return @bool ? 1 : 0;
        }
        /// <summary>
        /// Converts a integer number into an boolean (false or true)
        /// </summary>
        /// <param name="int">integer value</param>
        /// <returns>
        /// If integer number is greater to 0, return true. <br/>
        /// If integer number is less or equal than 0, return false.
        /// </returns>
        public static bool ToBool(this int @int)
        {
            @int = Mathf.Clamp(@int, 0, 1);
            return @int == 1;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="int">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsEmpty(this int[] @int)
        {
            if (@int == null)
                return false;
            else
                return @int.Length == 0;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="float">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsEmpty(this float[] @float)
        {
            if (@float == null)
                return false;
            else
                return @float.Length == 0;
        }
        /// <summary>
        /// Checks if all the elements in the array are null or if the array is empty
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="bool">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsEmpty(this bool[] @bool)
        {
            if (@bool == null)
                return false;
            else
                return @bool.Length == 0;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this int parameter, ref int globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this float parameter, ref float globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment(this bool parameter, ref bool globalVariable)
        {
            if (parameter == globalVariable)
                return false;

            globalVariable = parameter;
            return true;
        }
    }
}