using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ASP.Custom
{
    public static class Async
    {
        public static T Assignment<T>(T @object, MonoBehaviour monoBehaviour, int attempts = 10)
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
                while (result == null && times <= attempts);

                Debug.LogError($"The object cannot be assigned after {times} unsuccessful attempts!");
                action?.Invoke(default);
            }
        }

        public static void AddListener(Button button, UnityAction call, MonoBehaviour monoBheviour, int attempts = 10)
        {
            monoBheviour.StartCoroutine(_routine());

            IEnumerator _routine()
            {
                int times = 0;
                bool isNull;

                do
                {
                    isNull = button == null;
                    yield return new WaitForEndOfFrame();
                    times++;
                }
                while (isNull || times <= attempts);

                if (!isNull)
                    button.onClick.AddListener(call);
                else
                    Debug.LogError($"The object cannot be assigned after {times} unsuccessful attempts!");
            }
        }
    }
}