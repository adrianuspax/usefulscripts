using System;

namespace ASP.SceneManagement
{
    /// <summary>
    /// Struct that stores the scene name
    /// </summary>
    [Serializable]
    public struct Scene
    {
        /// <summary>
        /// Scene name
        /// </summary>
        public string name;
        /// <summary>
        /// Construct that assigns the scene name
        /// </summary>
        /// <param name="name">Name of the scene to be assigned</param>
        public Scene(string name)
        {
            this.name = name;
        }

        public static bool operator ==(Scene sceneA, Scene sceneB)
        {
            return sceneA.Equals(sceneB);
        }

        public static bool operator !=(Scene sceneA, Scene sceneB)
        {
            return !sceneA.Equals(sceneB);
        }

        public override readonly bool Equals(object obj)
        {
            if (obj is not Scene)
                return false;

            Scene s = (Scene)obj;
            return name == s.name;
        }

        public override readonly int GetHashCode()
        {
            return name == null ? 0 : name.GetHashCode();
        }
    }
    /// <summary>
    /// Class that manages the scenes
    /// </summary>
    public class SceneManager
    {
        /// <summary>
        /// Load the scene
        /// </summary>
        /// <param name="scene">Create a new instance <see cref="Scene"/> with the name of the scene and assign it as <paramref name="scene"/></param>
        public static void Load(Scene scene)
        {
            PreviousScene = new(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.name);
            Debug.Log($"ScenesManagement.Load(scene.name<{scene.name}>)");
        }
        /// <summary>
        /// Load the scene
        /// </summary>
        /// <param name="scene">Scene name</param>
        public static void Load(string scene)
        {
            PreviousScene = new(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            Debug.Log($"ScenesManagement.Load(scene<{scene}>)");
        }
        /// <summary>
        /// Checks if the scene is currently active
        /// </summary>
        /// <param name="scene">Create a new instance <see cref="Scene"/> with the name of the scene and assign it as <paramref name="scene"/></param>
        /// <returns>Returns true if the scene is currently active</returns>
        public static bool GetIsActiveScene(Scene scene)
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == scene.name;
        }
        /// <summary>
        /// Checks if the scene is currently active
        /// </summary>
        /// <param name="sceneName">Scene name</param>
        /// <returns>Returns true if the scene is currently active</returns>
        public static bool GetIsActiveScene(string sceneName)
        {
            return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == sceneName;
        }
        /// <summary>
        /// Saves the current scene (only in editor mode)
        /// </summary>
        public static void SaveCurrentScene()
        {
#if UNITY_EDITOR
            bool conditional =
            UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode ||
            UnityEditor.EditorApplication.isCompiling ||
            UnityEditor.EditorApplication.isUpdating;

            if (conditional)
                return;

            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            bool saved = UnityEditor.SceneManagement.EditorSceneManager.SaveScene(scene);

            if (saved)
                Debug.Log($"The scene {scene.name} saved<{saved}>", forceDebug: true);
            else
                Debug.LogError($"The scene {scene.name} saved<{saved}>");
#else
            return;
#endif
        }
        /// <summary>
        /// Returns the name of the previous scene
        /// </summary>
        public static Scene PreviousScene
        {
            get;
            private set;
        }
        /// <summary>
        /// Returns the name of the current scene
        /// </summary>
        public static Scene CurrentScene
        {
            get => new(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
