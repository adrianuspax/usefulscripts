using System.Collections;
using UnityEngine;

namespace ASP.Extensions
{
    public static class CanvasGroupExtensions
    {
        private static Coroutine coroutine;
        /// <summary>
        /// FadeIn or FadeOut of all graphic elements
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="alpha">Panel Fade in a range from 0 to 1</param>
        public static void SetAlpha(this CanvasGroup canvasGroup, float alpha)
        {
            if (canvasGroup.alpha == alpha)
                return;

            alpha = Mathf.Clamp01(alpha);
            canvasGroup.alpha = alpha;
        }

        public static void SetAlpha(this CanvasGroup[] canvasGroup, float alpha)
        {
            alpha = Mathf.Clamp01(alpha);

            foreach (CanvasGroup cg in canvasGroup)
            {
                cg.alpha = alpha;
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="monoBehaviour"></param>
        /// <param name="totalTime"></param>
        public static void FadeIn(this CanvasGroup canvasGroup, MonoBehaviour monoBehaviour, float totalTime = 1f)
        {
            monoBehaviour.StartCoroutine(_fadeIn());

            IEnumerator _fadeIn()
            {
                float runningTime, t, alpha;
                runningTime = 0f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(0f, 1f, t);

                    SetAlpha(canvasGroup, alpha);
                    yield return null;
                }

                SetAlpha(canvasGroup, 1f);
            }
        }
        /// <summary>
        /// Fade in of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="monoBehaviour"></param>
        /// <param name="previousAlpha"></param>
        /// <param name="totalTime"></param>
        public static void FadeIn(this CanvasGroup[] canvasGroup, MonoBehaviour monoBehaviour, float totalTime = 1f)
        {
            monoBehaviour.StartCoroutine(_fadeIn());

            IEnumerator _fadeIn()
            {
                float runningTime, t, alpha;
                runningTime = 0f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(0f, 1f, t);

                    foreach (CanvasGroup group in canvasGroup)
                    {
                        SetAlpha(group, alpha);
                    }

                    yield return null;
                }

                foreach (CanvasGroup group in canvasGroup)
                {
                    SetAlpha(group, 1f);
                }
            }
        }
        /// <summary>
        /// Fade out of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="monoBehaviour"></param>
        /// <param name="totalTime"></param>
        public static void FadeOut(this CanvasGroup canvasGroup, MonoBehaviour monoBehaviour, float totalTime = 1f)
        {
            monoBehaviour.StartCoroutine(_fadeOut());

            IEnumerator _fadeOut()
            {
                float runningTime, t, alpha, previousAlpha;
                runningTime = 0f;
                previousAlpha = canvasGroup.alpha;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(previousAlpha, 0f, t);

                    SetAlpha(canvasGroup, alpha);
                    yield return null;
                }

                SetAlpha(canvasGroup, 0f);
            }
        }
        /// <summary>
        /// Fade out of the panel and all its graphic elements
        /// </summary>
        /// <param name="canvasGroup"></param>
        /// <param name="monoBehaviour"></param>
        /// <param name="previousAlpha"></param>
        /// <param name="totalTime"></param>
        public static void FadeOut(this CanvasGroup[] canvasGroup, MonoBehaviour monoBehaviour, float totalTime = 1f)
        {
            monoBehaviour.StartCoroutine(_fadeOut());

            IEnumerator _fadeOut()
            {
                float runningTime, t, alpha, previousAlpha;
                runningTime = 0f;
                previousAlpha = 1f;

                while (runningTime < totalTime)
                {
                    runningTime += Time.deltaTime;
                    t = runningTime / totalTime;

                    alpha = Mathf.Lerp(previousAlpha, 0f, t);

                    foreach (CanvasGroup group in canvasGroup)
                    {
                        SetAlpha(group, alpha);
                    }

                    yield return null;
                }

                foreach (CanvasGroup group in canvasGroup)
                {
                    SetAlpha(group, 0f);
                }
            }
        }

        private static IEnumerator AlphaPingPong(CanvasGroup canvasGroup, float frequence)
        {
            float t = 0;

            do
            {
                t += Time.deltaTime;
                canvasGroup.alpha = Mathf.PingPong(t * frequence, 1f);
                yield return null;
            }
            while (coroutine != null);
            coroutine = null;
        }

        public static void StartAlphaPingPong(this CanvasGroup canvasGroup, float frequence, MonoBehaviour monoBehaviour)
        {
            coroutine = monoBehaviour.StartCoroutine(AlphaPingPong(canvasGroup, frequence));
        }

        public static void StopAlphaPingPong(this CanvasGroup canvasGroup, MonoBehaviour monoBehaviour, float returnAlpha = 1f)
        {
            coroutine = null;
            monoBehaviour.StopCoroutine(nameof(AlphaPingPong));
            returnAlpha = Mathf.Clamp01(returnAlpha);
            canvasGroup.alpha = returnAlpha;
        }
    }
}


