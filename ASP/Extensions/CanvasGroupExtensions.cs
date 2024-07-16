using System.Collections;
using UnityEngine;

namespace ASP.Extensions
{
    public static class CanvasGroupExtensions
    {
        private static Coroutine pingPongCoroutine;
        /// <summary>
        /// Set alpha in Canvas Group
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="alpha">Panel Fade in a range from 0 to 1</param>
        public static void SetAlpha(this CanvasGroup canvasGroup, float alpha)
        {
            if (canvasGroup.alpha == alpha)
                return;

            alpha = Mathf.Clamp01(alpha);
            canvasGroup.alpha = alpha;
        }
        /// <summary>
        /// Set alpha in Canvas Group Array
        /// </summary>
        /// <param name="canvasGroup">Canvas Group Array</param>
        /// <param name="alpha">Panel Fade in a range from 0 to 1</param>
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
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup canvasGroup, float totalTime, MonoBehaviour monoBehaviour)
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
        /// <param name="canvasGroup">Canvas Group Array</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeIn(this CanvasGroup[] canvasGroup, float totalTime, MonoBehaviour monoBehaviour)
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
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeOut(this CanvasGroup canvasGroup, float totalTime, MonoBehaviour monoBehaviour)
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
        /// <param name="canvasGroup">Canvas Group Array</param>
        /// <param name="totalTime">Total time animation</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void FadeOut(this CanvasGroup[] canvasGroup, float totalTime, MonoBehaviour monoBehaviour)
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
        /// <summary>
        /// Start Ping Pong Alpha
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="frequence">frequence of ping pong</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void StartAlphaPingPong(this CanvasGroup canvasGroup, float frequence, MonoBehaviour monoBehaviour)
        {
            pingPongCoroutine = monoBehaviour.StartCoroutine(AlphaPingPong(canvasGroup, frequence));
        }
        /// <summary>
        /// Stop Ping Pong Alpha
        /// </summary>
        /// <param name="canvasGroup">Canvas Group</param>
        /// <param name="returnAlpha">Return the alpha to Canvas Group</param>
        /// <param name="monoBehaviour">Mono Behaviour to Coroutine (use this)</param>
        public static void StopAlphaPingPong(this CanvasGroup canvasGroup, float returnAlpha, MonoBehaviour monoBehaviour)
        {
            pingPongCoroutine = null;
            monoBehaviour.StopCoroutine(nameof(AlphaPingPong));
            returnAlpha = Mathf.Clamp01(returnAlpha);
            canvasGroup.alpha = returnAlpha;
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
            while (pingPongCoroutine != null);
            pingPongCoroutine = null;
        }
    }
}


