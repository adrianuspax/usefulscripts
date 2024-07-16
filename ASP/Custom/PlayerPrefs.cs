namespace ASP
{
    /// <summary>
    /// PlayerPrefs is a class that stores Player preferences between game sessions.<br/>
    /// It can store string, float and integer values into the user’s platform registry.
    /// </summary>
    public class PlayerPrefs
    {
        /// <summary>
        /// Struct to manipulate <see cref="UnityEngine.PlayerPrefs"/> whose key is an integer.
        /// </summary>
        public struct Integer
        {
            /// <summary>
            /// Key name
            /// </summary>
            public string name;
            /// <summary>
            /// Construct to store the key name
            /// </summary>
            /// <param name="name">Key name</param>
            public Integer(string name)
            {
                this.name = name;
            }
            /// <summary>
            /// Assign the entire <paramref name="value"/> to <paramref name="key"/>
            /// </summary>
            /// <param name="key">Create a new instance <see cref="Integer"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <param name="value">Integer value to be stored</param>
            public static void Set(Integer key, int value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                int currentValue = UnityEngine.PlayerPrefs.GetInt(key.name);

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetInt(key.name, value);
            }
            /// <summary>
            /// Returns the value corresponding to key in the preference file if it exists.
            /// </summary>
            /// <param name="key">Created instance <see cref="Integer"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>Return integer value</returns>
            public static int Get(Integer key)
            {
                return UnityEngine.PlayerPrefs.GetInt(key.name);
            }
            /// <summary>
            /// Returns true if the given key exists in PlayerPrefs, otherwise returns false.
            /// </summary>
            /// <param name="key">Created instance <see cref="Integer"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>return boolean value</returns>
            public static bool HasSaved(Integer key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }
            /// <summary>
            /// Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
            /// </summary>
            /// <param name="key">Created instance <see cref="Integer"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            public static void Delete(Integer key)
            {
                UnityEngine.PlayerPrefs.DeleteKey(key.name);
            }
        }
        /// <summary>
        /// Struct to manipulate <see cref="UnityEngine.PlayerPrefs"/> whose key is an floater.
        /// </summary>
        public struct Floater
        {
            /// <summary>
            /// Key name
            /// </summary>
            public string name;
            /// <summary>
            /// Construct to store the key name
            /// </summary>
            /// <param name="name">Key name</param>
            public Floater(string name)
            {
                this.name = name;
            }
            /// <summary>
            /// Assign the entire <paramref name="value"/> to <paramref name="key"/>
            /// </summary>
            /// <param name="key">Create a new instance <see cref="Floater"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <param name="value">Floater value to be stored</param>
            public static void Set(Floater key, float value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                float currentValue = UnityEngine.PlayerPrefs.GetFloat(key.name);

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetFloat(key.name, value);
            }
            /// <summary>
            /// Returns the value corresponding to key in the preference file if it exists.
            /// </summary>
            /// <param name="key">Created instance <see cref="Floater"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>Return floater value</returns>
            public static float Get(Floater key)
            {
                return UnityEngine.PlayerPrefs.GetFloat(key.name);
            }
            /// <summary>
            /// Returns true if the given key exists in PlayerPrefs, otherwise returns false.
            /// </summary>
            /// <param name="key">Created instance <see cref="Floater"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>return boolean value</returns>
            public static bool HasSaved(Floater key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }
            /// <summary>
            /// Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
            /// </summary>
            /// <param name="key">Created instance <see cref="Floater"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            public static void Delete(Floater key)
            {
                if (UnityEngine.PlayerPrefs.HasKey(key.name))
                {
                    UnityEngine.PlayerPrefs.DeleteKey(key.name);
                    Debug.Log($"The \"{key.name}\" has been wiped clean on your machine!", forceDebug: true);
                    return;
                }

                Debug.LogWarning($"\"{key.name}\" is no save recorded on your machine!", default);
            }
        }
        /// <summary>
        /// Struct to manipulate <see cref="UnityEngine.PlayerPrefs"/> whose key is an string.
        /// </summary>
        public struct String
        {
            /// <summary>
            /// Key name
            /// </summary>
            public string name;
            /// <summary>
            /// Construct to store the key name
            /// </summary>
            /// <param name="name">Key name</param>
            public String(string name)
            {
                this.name = name;
            }
            /// <summary>
            /// Assign the entire <paramref name="value"/> to <paramref name="key"/>
            /// </summary>
            /// <param name="key">Create a new instance <see cref="String"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <param name="value">String value to be stored</param>
            public static void Set(String key, string value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                string currentValue = UnityEngine.PlayerPrefs.GetString(key.name);

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetString(key.name, value);
            }
            /// <summary>
            /// Returns the value corresponding to key in the preference file if it exists.
            /// </summary>
            /// <param name="key">Created instance <see cref="String"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>Return string value</returns>
            public static string Get(String key)
            {
                return UnityEngine.PlayerPrefs.GetString(key.name);
            }
            /// <summary>
            /// Returns true if the given key exists in PlayerPrefs, otherwise returns false.
            /// </summary>
            /// <param name="key">Created instance <see cref="String"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>return boolean value</returns>
            public static bool HasSaved(String key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }
            /// <summary>
            /// Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
            /// </summary>
            /// <param name="key">Created instance <see cref="String"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            public static void Delete(String key)
            {
                UnityEngine.PlayerPrefs.DeleteKey(key.name);
            }
        }
        /// <summary>
        /// Struct to manipulate <see cref="UnityEngine.PlayerPrefs"/> whose key is an boolean.
        /// </summary>
        public struct Boolean
        {
            /// <summary>
            /// Key name
            /// </summary>
            public string name;
            /// <summary>
            /// Construct to store the key name
            /// </summary>
            /// <param name="name">Key name</param>
            public Boolean(string name)
            {
                this.name = name;
            }
            /// <summary>
            /// Assign the entire <paramref name="value"/> to <paramref name="key"/>
            /// </summary>
            /// <param name="key">Create a new instance <see cref="Boolean"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <param name="value">Boolean value to be stored</param>
            public static void Set(Boolean key, bool value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                bool currentValue = UnityEngine.PlayerPrefs.GetInt(key.name) != 0;

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetInt(key.name, value ? 1 : 0);
            }
            /// <summary>
            /// Returns the value corresponding to key in the preference file if it exists.
            /// </summary>
            /// <param name="key">Created instance <see cref="Boolean"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>Return boolean value</returns>
            public static bool Get(Boolean key)
            {
                return UnityEngine.PlayerPrefs.GetInt(key.name) != 0;
            }
            /// <summary>
            /// Returns true if the given key exists in PlayerPrefs, otherwise returns false.
            /// </summary>
            /// <param name="key">Created instance <see cref="Boolean"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            /// <returns>return boolean value</returns>
            public static bool HasSaved(Boolean key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }
            /// <summary>
            /// Removes the given key from the PlayerPrefs. If the key does not exist, DeleteKey has no impact.
            /// </summary>
            /// <param name="key">Created instance <see cref="Boolean"/> with the name of the stored key and assign it as <paramref name="key"/></param>
            public static void Delete(Boolean key)
            {
                UnityEngine.PlayerPrefs.DeleteKey(key.name);
            }
        }
    }
}
