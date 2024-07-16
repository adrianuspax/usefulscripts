using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.PropertyVariants;
using UnityEngine.Localization.PropertyVariants.TrackedObjects;
using UnityEngine.Localization.PropertyVariants.TrackedProperties;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ASP.Extensions
{
    /// <summary>
    /// Code extension for Text Mesh Pro UGUI
    /// </summary>
    public static class TextMeshProUGUIExtensions
    {
        private static Coroutine coroutine;
        /// <summary>
        /// Set Text Mesh Pro's alpha directly
        /// </summary>
        /// <param name="textMeshPro">Text Mesh Pro UGUI</param>
        /// <param name="alpha">Text Mesh Pro alpha value between 0 and 1</param>
        public static void SetAlpha(this TextMeshProUGUI textMeshPro, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            Color color = textMeshPro.color;
            color.a = alpha;
            textMeshPro.color = color;
        }
        /// <summary>
        /// Set Localization String Reference
        /// </summary>
        /// <param name="tmp">Text Mesh Pro UGUI</param>
        /// <param name="entry">Reference to the <see cref="UnityEngine.Localization.Tables.TableEntry.Key"/> or <see cref="UnityEngine.Localization.Tables.TableEntry.KeyId"</param>
        /// <param name="table">Reference to the <see cref="UnityEngine.Localization.Tables.LocalizationTable.TableCollectionName"/> or <see cref="UnityEngine.Localization.Tables.SharedTableData.TableCollectionNameGuid"</param>
        /// <param name="monoBehaviour">Mono Behaviour</param>
        /// <returns>Returns true if the localization reference was successfully assigned</returns>
        public static bool SetLocalizationStringReference(this TextMeshProUGUI tmp, string entry, string table, MonoBehaviour monoBehaviour)
        {
            if (tmp.TryGetComponent(out GameObjectLocalizer gameObjectLocalizer))
            {
                TrackedUGuiGraphic trackedText = gameObjectLocalizer.GetTrackedObject<TrackedUGuiGraphic>(tmp);
                LocalizedStringProperty textVariant = trackedText.GetTrackedProperty<LocalizedStringProperty>("m_text");
                textVariant.LocalizedString.SetReference(table, entry);
                coroutine ??= monoBehaviour.StartCoroutine(_applyLocaleVariant());
            }
            else if (tmp.TryGetComponent(out LocalizeStringEvent localizeStringEvent))
            {
                localizeStringEvent.StringReference.SetReference(table, entry);
            }
            else
            {
                Debug.LogWarning($"The referenced TextMeshPro has no GameObjectLocalizer or LocalizeStringEvent built-in!", monoBehaviour);
            }

            return coroutine == null;

            IEnumerator _applyLocaleVariant()
            {
                AsyncOperationHandle operation;

                do
                {
                    operation = gameObjectLocalizer.ApplyLocaleVariant(LocalizationSettings.SelectedLocale);
                    yield return null;
                } while (!operation.IsDone);

                coroutine = null;
            }
        }
        /// <summary>
        /// Set Localization String
        /// </summary>
        /// <param name="tableEntryReference">The key that the string is stored in StringTable</param>
        /// <param name="tableReference">The key that the string is stored in Table Collection</param>
        /// <returns>Return the localization string</returns>
        public static void SetLocalizationString(this TextMeshProUGUI tmp, string tableEntryReference, string tableReference = "StringTable")
        {
            if (string.IsNullOrEmpty(tableReference))
            {
                Debug.LogWarning($"The {nameof(tableReference)} cannot be null or empty!", default);
                return;
            }

            if (string.IsNullOrEmpty(tableEntryReference))
            {
                Debug.LogWarning($"The {nameof(tableEntryReference)} cannot be null or empty!", default);
                return;
            }

            AsyncOperationHandle<string> operation = LocalizationSettings.StringDatabase.GetLocalizedStringAsync(tableReference, tableEntryReference);

            _updateString(operation);

            void _updateString(AsyncOperationHandle<string> operation)
            {
                if (!operation.IsDone)
                {
                    operation.Completed += _updateString;
                    return;
                }

                tmp.text = operation.Result;
            }
        }
        /// <summary>
        /// Set Localization Font
        /// </summary>
        /// <param name="tableEntryReference">The key that the string is stored in StringTable</param>
        /// <param name="tableReference">The key that the string is stored in Table Collection</param>
        public static void SetLocalizationFont(this TextMeshProUGUI tmp, string tableEntryReference, string tableReference = "AssetTable")
        {
            if (string.IsNullOrEmpty(tableReference))
            {
                Debug.LogWarning($"The {nameof(tableReference)} cannot be null or empty!", default);
                return;
            }

            if (string.IsNullOrEmpty(tableEntryReference))
            {
                Debug.LogWarning($"The {nameof(tableEntryReference)} cannot be null or empty!", default);
                return;
            }

            TMP_FontAsset font = LocalizationSettings.AssetDatabase.GetLocalizedAssetAsync<TMP_FontAsset>(tableReference, tableEntryReference).Result;

            if (font == null)
            {
                Debug.LogWarning($"The key was not found: \"{tableEntryReference}\"!", default);
                return;
            }

            tmp.font = font;
        }
        /// <summary>
        /// Set Localization Material
        /// </summary>
        /// <param name="tableEntryReference">The key that the string is stored in StringTable</param>
        /// <param name="tableReference">The key that the string is stored in Table Collection</param>
        public static void SetLocalizationMaterial(this TextMeshProUGUI tmp, string tableEntryReference, string tableReference = "AssetTable")
        {
            if (string.IsNullOrEmpty(tableReference))
            {
                Debug.LogWarning($"The {nameof(tableReference)} cannot be null or empty!", default);
                return;
            }

            if (string.IsNullOrEmpty(tableEntryReference))
            {
                Debug.LogWarning($"The {nameof(tableEntryReference)} cannot be null or empty!", default);
                return;
            }

            Material material = LocalizationSettings.AssetDatabase.GetLocalizedAssetAsync<Material>(tableReference, tableEntryReference).Result;

            if (material == null)
            {
                Debug.LogWarning($"The key was not found: \"{tableEntryReference}\"!", default);
                return;
            }

            tmp.fontMaterial = material;
        }
        /// <summary>
        /// Set a Color From a Gradient Colors
        /// </summary>
        /// <param name="tmp">Text Mesh Pro</param>
        /// <param name="alpha">Text Mesh Pro Alpha</param>
        /// <param name="time">Time of evaluation gradient (0 ~ 1)</param>
        /// <param name="colors">colors of gradient</param>
        public static void SetColorFromGradient(this TextMeshProUGUI tmp, float alpha, float time, params Color[] colors)
        {
            int length = colors.Length;
            GradientColorKey[] GCK;
            GradientAlphaKey[] GAK;
            Gradient gradient = new();

            GAK = new GradientAlphaKey[1]
            {
                new(Mathf.Clamp01(alpha), 0.5f)
            };

            if (length == 1)
            {
                GCK = new GradientColorKey[2]
                {
                    new(colors[0], 0), new(colors[0], 1)
                };

                gradient.SetKeys(GCK, GAK);
                tmp.color = gradient.Evaluate(Mathf.Clamp01(time));
                return;
            }

            GCK = new GradientColorKey[length];

            for (int i = 0; i < length; i++)
            {
                GCK[i].color = colors[i];
                GCK[i].time = i / (length - 1f);
            }

            gradient.SetKeys(GCK, GAK);
            tmp.color = gradient.Evaluate(Mathf.Clamp01(time));
            return;
        }
    }
}
