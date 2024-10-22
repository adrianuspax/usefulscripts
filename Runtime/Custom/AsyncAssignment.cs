using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace ASP.Custom
{
    public static class AsyncAssignment
    {
        public static T Get<T>(T @object, MonoBehaviour monoBehaviour, int attempts = 10)
        {
            T result = default;
            IEnumerator routine = _routine((action) => result = action);
            monoBehaviour.StartCoroutine(routine);
            return result;

            IEnumerator _routine(UnityAction<T> action)
            {
                int times = 0;

                do
                {
                    result = @object;

                    if (result != null)
                    {
                        action?.Invoke(result);
                        yield break;
                    }

                    yield return new WaitForEndOfFrame();
                    times++;
                }
                while (result == null && times < attempts);

                Debug.LogError($"The object cannot be assigned after {times} unsuccessful attempts!");
                action?.Invoke(default);
            }
        }
    }
}