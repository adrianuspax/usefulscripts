namespace ASP
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerPrefs
    {
        public readonly struct Integer
        {
            public readonly string name;

            private Integer(string name)
            {
                this.name = name;
            }

            public static void Set(Integer key, int value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                int currentValue = UnityEngine.PlayerPrefs.GetInt(key.name);

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetInt(key.name, value);
            }

            public static int Get(Integer key)
            {
                return UnityEngine.PlayerPrefs.GetInt(key.name);
            }

            public static bool HasSaved(Integer key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }

            public static void Delete(Integer key)
            {
                if (UnityEngine.PlayerPrefs.HasKey(key.name))
                {
                    UnityEngine.PlayerPrefs.DeleteKey(key.name);
                    Debug.Log($"The \"{key.name}\" has been wiped clean on your machine!", forceDebug: true);
                    return;
                }

                Debug.LogWarning($"\"{key.name}\" is no save recorded on your machine!", default);
            }

            public static (Integer @null,
                           Integer autorunTimer)
            Key
            {
                get => (new(default),
                        new("autorunTimer"));
            }
        }

        public readonly struct Floater
        {
            public readonly string name;

            private Floater(string name)
            {
                this.name = name;
            }

            public static void Set(Floater key, float value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                float currentValue = UnityEngine.PlayerPrefs.GetFloat(key.name);

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetFloat(key.name, value);
            }

            public static float Get(Floater key)
            {
                return UnityEngine.PlayerPrefs.GetFloat(key.name);
            }

            public static bool HasSaved(Floater key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }

            public static void DeleteSave(Floater key)
            {
                if (UnityEngine.PlayerPrefs.HasKey(key.name))
                {
                    UnityEngine.PlayerPrefs.DeleteKey(key.name);
                    Debug.Log($"The \"{key.name}\" has been wiped clean on your machine!", forceDebug: true);
                    return;
                }

                Debug.LogWarning($"\"{key.name}\" is no save recorded on your machine!", default);
            }

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

            public static (Floater a,
                           Floater b)
            Key
            {
                get => (new(""),
                        new(""));
            }
        }

        public readonly struct String
        {
            public readonly string name;

            private String(string name)
            {
                this.name = name;
            }

            public static void Set(String key, string value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                string currentValue = UnityEngine.PlayerPrefs.GetString(key.name);

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetString(key.name, value);
            }

            public static string Get(String key)
            {
                return UnityEngine.PlayerPrefs.GetString(key.name);
            }

            public static bool HasSaved(String key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }

            public static void Delete(String key)
            {
                if (UnityEngine.PlayerPrefs.HasKey(key.name))
                {
                    UnityEngine.PlayerPrefs.DeleteKey(key.name);
                    Debug.Log($"The \"{key.name}\" has been wiped clean on your machine!", forceDebug: true);
                    return;
                }

                Debug.LogWarning($"\"{key.name}\" is no save recorded on your machine!", default);
            }

            public static (String a,
                           String b)
            Key
            {
                get => (new(""),
                        new(""));
            }
        }

        public readonly struct Boolean
        {
            public readonly string name;

            private Boolean(string name)
            {
                this.name = name;
            }

            public static void Set(Boolean key, bool value)
            {
                bool hasKey = UnityEngine.PlayerPrefs.HasKey(key.name);
                bool currentValue = UnityEngine.PlayerPrefs.GetInt(key.name) != 0;

                if ((value == currentValue) && hasKey)
                    return;

                UnityEngine.PlayerPrefs.SetInt(key.name, value ? 1 : 0);
            }

            public static bool Get(Boolean key)
            {
                return UnityEngine.PlayerPrefs.GetInt(key.name) != 0;
            }

            public static bool HasSaved(Boolean key)
            {
                return UnityEngine.PlayerPrefs.HasKey(key.name);
            }

            public static void Delete(Boolean key)
            {
                if (UnityEngine.PlayerPrefs.HasKey(key.name))
                {
                    UnityEngine.PlayerPrefs.DeleteKey(key.name);
                    Debug.Log($"The \"{key.name}\" has been wiped clean on your machine!", forceDebug: true);
                    return;
                }

                Debug.LogWarning($"\"{key.name}\" is no save recorded on your machine!", default);
            }

            public static (Boolean operatorMode,
                           Boolean autorunMode)
            Key
            {
                get => (new("operator"),
                        new("autorun"));
            }
        }
    }
}
