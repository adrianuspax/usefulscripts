using UnityEngine;

namespace ASP.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool IsNull(this GameObject gameObject)
        {
            return gameObject == null;
        }
    }
}
