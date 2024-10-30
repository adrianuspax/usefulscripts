using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ASP.Extensions
{
    public static class AsyncExtensions
    {
        public static void AsyncAddListener(this Button button, UnityAction call, MonoBehaviour monoBheviour, int attempts = 10)
        {
            Button result = default;
            IEnumerator routine = _routine(() => button.onClick.AddListener(call));
            monoBheviour.StartCoroutine(routine);

            IEnumerator _routine(UnityAction action)
            {
                int times = 0;

                do
                {
                    result = button;

                    if (result != null)
                    {
                        action?.Invoke();
                        yield break;
                    }

                    yield return new WaitForEndOfFrame();
                    times++;
                }
                while (result == null && times < attempts);

                Debug.LogError($"The call cannot be Add in Listener after {times} unsuccessful attempts!");
            }
        }
    }
}