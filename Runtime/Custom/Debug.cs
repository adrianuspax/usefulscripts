
namespace ASP
{
    /// <summary>
    /// Debug that will only be executed in the Unity Editor
    /// and thus prevent unnecessary log files from being generated after the build
    /// impacting the application's performance.
    /// </summary>
    public class Debug
    {
        /// <summary>
        /// If false, the log messages will remain inactive
        /// </summary>
        public static bool isActive;
        /// <summary>
        /// Logs a message to the Unity Console.
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="forceDebug">If Debug doesn't work, changing <paramref name="forceDebug"/> to true will make it work</param>
        public static void Log(object message, UnityEngine.Object context = default, bool forceDebug = false)
        {
#if UNITY_EDITOR
            if (isActive || forceDebug)
                UnityEngine.Debug.Log($"[{UnityEngine.Time.realtimeSinceStartup:F3}]: <color=green>{message}</color>", context);
#else
            return;
#endif
        }
        /// <summary>
        /// A variant of Debug.Log that logs a warning message to the console.
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        public static void LogWarning(object message, UnityEngine.Object context = default)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning($"[{UnityEngine.Time.realtimeSinceStartup:F3}]: <color=yellow>{message}</color>", context);
#else
            return;
#endif
        }
        /// <summary>
        /// A variant of Debug.Log that logs a warning message to the console.
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        /// <param name="context">Object to which the message applies.</param>
        public static void LogError(object message, UnityEngine.Object context = default)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning($"[{UnityEngine.Time.realtimeSinceStartup:F3}]: <color=red>{message}</color>", context);
#else
            return;
#endif
        }
    }
}
