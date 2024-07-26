using System;
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
        [Obsolete("Use GetComponentIfNull().")]
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
        [Obsolete("Use GetComponentIfNull().")]
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
        [Obsolete("Use GetComponentInChildrenIfNull().")]
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
        [Obsolete("Use GetComponentsInChildrenHeadersIfNull.")]
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
        [Obsolete("Use GetComponentsInChildrenHeadersIfNull.")]
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
        /// <summary>
        /// Assign a component of an object that has it from the object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the child that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentIfNull<T>(this Component component, ref T variable, params int[] childrenIndexes) where T : Component
        {
            if (variable == null)
            {
                Transform transform = component.transform;

                if (childrenIndexes == null || childrenIndexes.Length == 0)
                {
                    variable = transform.GetComponent<T>();
                    return true;
                }

                for (int i = 0; i < childrenIndexes.Length; i++)
                {
                    transform = transform.GetChild(childrenIndexes[i]);
                }

                variable = transform.GetComponent<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variable">Enter the variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentInChildrenIfNull<T>(this Component component, ref T variable, params int[] childrenIndexes) where T : Component
        {
            if (variable == null)
            {
                Transform transform = component.transform;

                if (childrenIndexes == null || childrenIndexes.Length == 0)
                {
                    variable = transform.GetComponentInChildren<T>();
                    return true;
                }

                for (int i = 0; i < childrenIndexes.Length; i++)
                {
                    transform = transform.GetChild(childrenIndexes[i]);
                }

                variable = transform.GetComponentInChildren<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function (And children's children)
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variables">Enter the array variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentsInAllChildrenIfNull<T>(this Component component, ref T[] variables, params int[] childrenIndexes) where T : Component
        {
            if (variables == null || variables.Length == 0)
            {
                Transform transform = component.transform;

                if (childrenIndexes == null || childrenIndexes.Length == 0)
                {
                    variables = transform.GetComponentsInChildren<T>();
                    return true;
                }

                for (int i = 0; i < childrenIndexes.Length; i++)
                {
                    transform = transform.GetChild(childrenIndexes[i]);
                }

                variables = transform.GetComponentsInChildren<T>();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Assign a component of an object that has it from the child of object that calls this function (No children of children)
        /// </summary>
        /// <typeparam name="T">Type of component</typeparam>
        /// <param name="component">Component of the object calling this function</param>
        /// <param name="variables">Enter the array variable that will receive the component</param>
        /// <param name="childrenIndexes">The index of the children that will assign the component. To take children from children, separate the hierarchy with commas</param>
        /// <returns>Returns true if the component is assigned, i.e. it was null</returns>
        public static bool GetComponentsInChildrenHeadersIfNull<T>(this Component component, ref T[] variables, params int[] childrenIndexes) where T : Component
        {
            if (variables == null || variables.Length == 0)
            {
                Transform header = component.transform;

                if (childrenIndexes == null || childrenIndexes.Length == 0)
                {
                    variables = new T[header.childCount];

                    for (int i = 0; i < variables.Length; i++)
                    {
                        variables[i] = header.GetChild(i).GetComponentInChildren<T>();
                    }

                    return true;
                }

                for (int i = 0; i < childrenIndexes.Length; i++)
                {
                    header = header.GetChild(childrenIndexes[i]);
                }

                variables = new T[header.childCount];

                for (int i = 0; i < variables.Length; i++)
                {
                    variables[i] = header.GetChild(i).GetComponentInChildren<T>();
                }

                return true;
            }

            return false;
        }
    }
}