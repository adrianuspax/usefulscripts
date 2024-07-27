namespace ASP.Extensions
{
    public static class StructExtensions
    {
        /// <summary>
        /// Checks if the array is empty
        /// </summary>
        /// <typeparam name="T">Generic Type (where T : Component)</typeparam>
        /// <param name="values">Generic Type Array</param>
        /// <returns>true if array components is null or empty</returns>
        public static bool IsEmpty<T>(this T[] values) where T : struct
        {
            return values.Length == 0;
        }
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Type of parameter and variable</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment<T>(this T parameter, ref T globalVariable) where T : struct
        {
            bool isEquals = parameter.Equals(globalVariable);

            if (isEquals)
                return false;

            globalVariable = parameter;
            return true;
        }
    }
}