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
        public static float GetClipLength(this Animator animator, string clipName)
        {
            int clipNameHash2;
            var length = -1f;
            var clipNameHash1 = Animator.StringToHash(clipName);

            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                clipNameHash2 = Animator.StringToHash(animator.runtimeAnimatorController.animationClips[i].name);

                if (clipNameHash1 == clipNameHash2)
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
        /// Returns the time of the animation clip
        /// </summary>
        /// <param name="id">ID of the animation clip you want to know the animation time of</param>
        /// <returns>Time in seconds of the animation clip</returns>
        public static float GetClipLength(this Animator animator, int id)
        {
            int clipNameHash;
            var length = -1f;

            for (int i = 0; i < animator.runtimeAnimatorController.animationClips.Length; i++)
            {
                clipNameHash = Animator.StringToHash(animator.runtimeAnimatorController.animationClips[i].name);

                if (id == clipNameHash)
                {
                    length = animator.runtimeAnimatorController.animationClips[i].length;
                    break;
                }
            }

            if (length < 0f)
            {
                Debug.LogWarning($"Could not find an animatorClip whose id is {id} in the {animator.name} animation!", default);
                return 0f;
            }

            return length;
        }
        /// <summary>
        /// Returns the sum of the time of the animations
        /// </summary>
        /// <param name="clipNames">Name of the animation clip you want to know the animation time sum of</param>
        /// <returns>Time in seconds of sum the animation clip</returns>
        public static float GetSumClipsLength(this Animator animator, params string[] clipNames)
        {
            var length = 0f;

            foreach (string clipName in clipNames)
                length += animator.GetClipLength(clipName);

            return length;
        }
        /// <summary>
        /// Returns the sum of the time of the animations
        /// </summary>
        /// <param name="ids">IDs of the animation clip you want to know the animation time sum of</param>
        /// <returns>Time in seconds of sum the animation clip</returns>
        public static float GetSumClipsLength(this Animator animator, params int[] ids)
        {
            var length = 0f;

            foreach (var id in ids)
                length += animator.GetClipLength(id);

            return length;
        }
    }
}
