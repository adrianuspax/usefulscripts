using UnityEngine;

namespace ASP.Extensions
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Assign a component of an object that has it from the object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        public static void GetComponentFrom<T>(this Component component, out T variable) where T : Component
        {
            variable = component.GetComponent<T>();
        }
        /// <summary>
        /// Assign a component of an object that has it from the object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        /// <param name="chieldIndex">The index of the child that will assign the component. To take children from children, separate the hierarchy with commas</param>
        public static void GetComponentFrom<T>(this Component component, out T variable, params int[] chieldIndex) where T : Component
        {
            Transform transform = component.transform.GetChild(chieldIndex[0]);

            for (int i = 1; i < chieldIndex.Length; i++)
            {
                transform = transform.GetChild(chieldIndex[i]);
            }

            variable = transform.GetComponent<T>();
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        /// <param name="childrenIndex">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        public static void GetComponentInChildrenFrom<T>(this Component component, out T variable, params int[] childrenIndex) where T : Component
        {
            Transform transform = component.transform.GetChild(childrenIndex[0]);

            for (int i = 1; i < childrenIndex.Length; i++)
            {
                transform = transform.GetChild(childrenIndex[i]);
            }

            variable = transform.GetComponentInChildren<T>();
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="array">Enter the array variable that will receive the component</param>
        public static void GetComponentsInChildrenFrom<T>(this Component component, out T[] array) where T : Component
        {
            array = new T[component.transform.childCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = component.transform.GetChild(i).GetComponentInChildren<T>();
            }
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="array">Enter the array variable that will receive the component</param>
        /// <param name="chieldIndex">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        public static void GetComponentsInChildrenFrom<T>(this Component component, out T[] array, params int[] chieldIndex) where T : Component
        {
            Transform header = component.transform.GetChild(chieldIndex[0]);

            for (int i = 1; i < chieldIndex.Length; i++)
            {
                header = header.GetChild(chieldIndex[i]);
            }

            array = new T[header.childCount];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = header.GetChild(i).GetComponentInChildren<T>();
            }
        }
        /// <summary>
        /// Checks if a component is null
        /// </summary>
        /// <param name="component">component</param>
        /// <returns>true if the component is null</returns>
        public static bool IsNull(this Component component)
        {
            return component == null;
        }
    }
}