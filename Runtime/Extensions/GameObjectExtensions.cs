using UnityEngine;

namespace ASP.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Checks if a Game Object is null
        /// </summary>
        /// <param name="gameObject">component</param>
        /// <returns>true if the gameObject is null</returns>
        public static bool IsNull(this GameObject gameObject)
        {
            return gameObject == null;
        }
    }
}
