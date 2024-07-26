using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace ASP.Editor
{
    /// <summary>
    /// Assignment Components Reflection to create Buttons in Inspector
    /// </summary>
    public class AssignmentComponentsReflection : MonoBehaviour
    {
        [CustomEditor(typeof(MonoBehaviour), true)]
        public class UniversalMethodButtonEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                GUILayout.Space(10);
                DrawDefaultInspector();
                GUILayout.Space(10);

                MonoBehaviour monoBehaviour = (MonoBehaviour)target;
                MethodInfo assignMethod = monoBehaviour.GetType().GetMethod("ComponentsAssignment", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                MethodInfo resetMethod = monoBehaviour.GetType().GetMethod("Reset", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                MethodInfo testMethod = monoBehaviour.GetType().GetMethod("Test", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();

                if (assignMethod != null)
                {

                    if (GUILayout.Button("ASSIGN", GUILayout.MaxWidth(200f), GUILayout.MaxHeight(25f)))
                    {
                        assignMethod.Invoke(monoBehaviour, null);
                    }
                }

                if (resetMethod != null)
                {
                    if (GUILayout.Button("RESET", GUILayout.MaxWidth(200f), GUILayout.MaxHeight(25f)))
                    {
                        resetMethod.Invoke(monoBehaviour, null);
                    }
                }

                if (testMethod != null)
                {
                    if (GUILayout.Button("TEST", GUILayout.MaxWidth(200f), GUILayout.MaxHeight(25f)))
                    {
                        testMethod.Invoke(monoBehaviour, null);
                    }
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }
        }
    }
}
