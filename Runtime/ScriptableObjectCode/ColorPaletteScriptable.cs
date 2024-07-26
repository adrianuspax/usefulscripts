using UnityEngine;

namespace ASP.Scriptables
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "ColorPalette", menuName = "ScriptableObjects/ColorPalette/Color", order = 1)]
    public class ColorPaletteScriptable : ScriptableObject
    {
        [SerializeField] private Color[] colorPalette;
        public Color[] Color => colorPalette;
    }
}