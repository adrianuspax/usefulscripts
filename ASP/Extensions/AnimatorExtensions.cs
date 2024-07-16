using UnityEngine;

namespace ASP.Extensions
{
    public static class AnimatorExtensions
    {
        /// <summary>
        /// Returns the time of the animation clip
        /// </summary>
        /// <param name="clipName">Name of the animation clip you want to know the animation time of</param>
        /// <returns>Time in seconds of the animation clip</returns>
        public static float GetAnimationClipLength(this Animator animator, string clipName)
        {
            float length = -1f;

            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                if (clipName == animator.runtimeAnimatorController.animationClips[i].name)
                {
                    length = animator.runtimeAnimatorController.animationClips[i].length;
                    break;
                }
            }

            if (length < 0f)
            {
                Debug.LogWarning($"Could not find an animatorClip whose name is {clipName} in the {animator.name} animation!", default);
                return 0f;
            }

            return length;
        }
        /// <summary>
        /// Returns the sum of the time of the animations
        /// </summary>
        /// <param name="clipNames">Name of the animation clip you want to know the animation time sum of</param>
        /// <returns>Time in seconds of sum the animation clip</returns>
        public static float GetSumAnimationClipLength(this Animator animator, params string[] clipNames)
        {
            float length = 0f;

            foreach (string clipName in clipNames)
            {
                length += animator.GetAnimationClipLength(clipName);
            }

            return length;
        }
    }
}
