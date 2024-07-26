using UnityEngine;

namespace ASP.Scriptables
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "Gradient", menuName = "ScriptableObjects/ColorPallete/Gradient", order = 1)]
    public class GradientScriptable : ScriptableObject
    {
        [SerializeField] private Gradient gradient;
        public Gradient Gardient => gradient;
    }
}
