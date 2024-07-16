namespace ASP.Extensions
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Compares elements of the same type and assigns the value of the parameter to the variable if the values are not equal.
        /// </summary>
        /// <typeparam name="T">Type of parameter and variable</typeparam>
        /// <param name="parameter">The parameter that will be compared</param>
        /// <param name="globalVariable">The variable that will be compared and then assigned if the values are not equal.</param>
        /// <returns>"attributed" returns the value assigned to the variable and "wasAttributed" returns true if the assignment to the variable occurred.</returns>
        public static bool ComparativeAssignment<T>(this T parameter, ref T globalVariable)
        {
            bool isEquals = parameter.Equals(globalVariable);

            if (isEquals)
                return false;

            globalVariable = parameter;
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="objects">Array</param>
        /// <returns>true if array objects is null or empty</returns>
        public static bool IsNullOrEmpty<T>(this T[] objects)
        {
            bool isNull = true;

            if (objects.Length == 0)
            {
                isNull = true;
            }
            else
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (objects[i] != null)
                    {
                        isNull = false;
                        break;
                    }
                }
            }

            return isNull;
        }
    }
}
