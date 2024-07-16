
namespace ASP
{
    /// <summary>
    /// Debug that will only be executed in the Unity Editor
    /// and thus prevent unnecessary log files from being generated after the build
    /// impacting the application's performance.
    /// </summary>
    public class Debug
    {
        public static bool isActive;
        /// <summary>
        /// Class containing methods to ease debugging while developing a game (Like Debug.Log()).
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public static void Log(object message, UnityEngine.Object context = default, bool forceDebug = false)
        {
            if (isActive || forceDebug)
            {
                Call(() => UnityEngine.Debug.Log($"[{UnityEngine.Time.realtimeSinceStartup:F3}]: <color=green>{message}</color>", context));
            }
        }

        public static void LogWarning(object message, UnityEngine.Object context = default)
        {
            Call(() => UnityEngine.Debug.LogWarning($"[{UnityEngine.Time.realtimeSinceStartup:F3}]: <color=yellow>{message}</color>", context));
        }

        public static void LogError(object message, UnityEngine.Object context = default)
        {
            Call(() => UnityEngine.Debug.LogWarning($"[{UnityEngine.Time.realtimeSinceStartup:F3}]: <color=red>{message}</color>", context));
        }

        private static void Call(System.Action action)
        {
#if UNITY_EDITOR
            action?.Invoke();
#else
        return;
#endif
        }
    }
}
