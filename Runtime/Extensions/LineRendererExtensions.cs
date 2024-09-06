using System.Collections;
using UnityEngine;

namespace ASP.Extensions
{
    public static class LineRendererExtensions
    {
        private static Coroutine _coroutine = null;
        private static MonoBehaviour _monoBehaviour = null;
        private static readonly MaterialPropertyBlock _materialPropertyBlock = new();
        private const string TEXTURE = "_MainTex";
        private const string TEXTURE_ST = "_MainTex_ST";

        public static void SetTexture(this LineRenderer lineRenderer, Texture texture, int materialIndex = 0)
        {
            if (lineRenderer.materials[materialIndex].HasProperty(TEXTURE))
            {
                lineRenderer.GetPropertyBlock(_materialPropertyBlock, materialIndex);
                _materialPropertyBlock.SetTexture(TEXTURE, texture);
                lineRenderer.SetPropertyBlock(_materialPropertyBlock, materialIndex);
            }
        }

        public static void SetOffset(this LineRenderer lineRenderer, Vector2 offset, int materialIndex = 0)
        {
            if (lineRenderer.materials[materialIndex].HasProperty(TEXTURE_ST))
            {
                Vector4 value = new(1f, 1f, offset.x, offset.y);
                lineRenderer.GetPropertyBlock(_materialPropertyBlock, materialIndex);
                _materialPropertyBlock.SetVector(TEXTURE_ST, value);
                lineRenderer.SetPropertyBlock(_materialPropertyBlock, materialIndex);
            }
        }

        public static void StartDynamicOffset(this LineRenderer lineRenderer, Vector2 speed, MonoBehaviour monoBehaviour, int materialIndex = 0)
        {
            if (lineRenderer.materials[materialIndex].HasProperty(TEXTURE_ST))
            {
                _monoBehaviour = monoBehaviour;
                _coroutine ??= monoBehaviour.StartCoroutine(_run());
            }

            IEnumerator _run()
            {
                float time = 0f;

                do
                {
                    time += Time.deltaTime;
                    lineRenderer.SetOffset(speed * time, materialIndex);
                    yield return null;
                }
                while (speed != Vector2.zero);
                _coroutine = null;
            }
        }

        public static void StopDynamicOffset(this LineRenderer lineRenderer, int materialIndex = 0)
        {
            if (_monoBehaviour == null || _coroutine == null)
                return;

            lineRenderer.SetOffset(Vector2.zero, materialIndex);
            _monoBehaviour.StopCoroutine(_coroutine);
            _monoBehaviour = null;
        }
    }
}
