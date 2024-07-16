using UnityEngine;

namespace ASP
{
    /// <summary>
    /// It refers to the direction (more specifically, the direction) of the position in relation to the screen or user
    /// </summary>
    public class Direction
    {
        /// <summary>
        /// The global form index (it's the same as the screen)
        /// </summary>
        private static readonly
        (
        int none,
        int left,
        int right,
        int center,
        int up,
        int down,
        int topR,
        int topL,
        int bottonR,
        int bottonL
        ) index = ( -1, 0, 1, 2, 3, 4, 5, 6, 7, 8 );
        /// <summary>
        /// Position in relation to the user facing the screen
        /// </summary>
        public enum User
        {
            /// <summary>
            /// No position
            /// </summary>
            none = -1,
            /// <summary>
            /// To the right of the user, to the left on the screen
            /// </summary>
            hisRight = 0,
            /// <summary>
            /// To the left of the user, to the right on the screen
            /// </summary>
            hisLeft = 1,
            /// <summary>
            /// The center of the user (the same in relation to the screen)
            /// </summary>
            hisCenter = 2,
            /// <summary>
            /// Above the user (top of the screen)
            /// </summary>
            upper = 3,
            /// <summary>
            /// User tab (bottom of screen)
            /// </summary>
            lower = 4,
            /// <summary>
            /// Top right to the user (top left to the screen)
            /// </summary>
            hisTopRight = 5,
            /// <summary>
            /// Top left to the user (top right to the screen)
            /// </summary>
            hisTopLeft = 6,
            /// <summary>
            /// Bottom right to the user (bottom left to the screen)
            /// </summary>
            hisBottomRight = 7,
            /// <summary>
            /// Bottom left to the user (bottom right to the screen)
            /// </summary>
            hisBottomLeft = 8
        };
        /// <summary>
        /// Screen position
        /// </summary>
        public enum Screen
        {
            /// <summary>
            /// No position
            /// </summary>
            none = -1,
            /// <summary>
            /// To the left on the screen
            /// </summary>
            left = 0,
            /// <summary>
            /// To the right on the screen
            /// </summary>
            right = 1,
            /// <summary>
            /// The center of the screen
            /// </summary>
            center = 2,
            /// <summary>
            /// Top of the screen
            /// </summary>
            top = 3,
            /// <summary>
            /// Botton of the screen
            /// </summary>
            bottom = 4,
            /// <summary>
            /// Top right of the screen
            /// </summary>
            topRight = 5,
            /// <summary>
            /// Top left of the screen
            /// </summary>
            topLeft = 6,
            /// <summary>
            /// Bottom right of the screen
            /// </summary>
            bottomRight = 7,
            /// <summary>
            /// bottom left of the screen
            /// </summary>
            bottomLeft = 8
        };
        /// <summary>
        /// Returns the index that the User enum refers to
        /// </summary>
        public static
            (
            int none,
            int hisRight,
            int hisLeft,
            int hisCenter,
            int upper,
            int lower,
            int hisTopRight,
            int hisTopLeft,
            int hisBottomRight,
            int hisBottomLeft
            ) UserIndex => index;
        /// <summary>
        /// Returns the index that the Screen enum refers to
        /// </summary>
        public static
            (
            int none,
            int left,
            int right,
            int center,
            int top,
            int bottom,
            int topRight,
            int topLeft,
            int bottomRight,
            int bottomLeft
            ) ScreenIndex => index;
        /// <summary>
        /// Screen Index to GameObject child index
        /// </summary>
        /// <param name="index">The index of the gameObject hierarchy as a child</param>
        /// <returns>
        /// index: Returns the relative index that the gameObject will have when positioned in relation to the screen,
        /// according to the index assigned to the Screen enum element.
        /// side: Same return as index but converted to enum Screen.
        /// </returns>
        public static (int index, Screen side) IndexAdjustment(int index)
        {
            if (index < 0 || index > 2)
            {
                Debug.LogWarning($"The index value must be between 0 and 2, but the value entered was {index}!", default);
                return (-1, Screen.none);
            }

            int i = (int)(3.5f * index - 1.5f * Mathf.Pow(index, 2));
            return (i, (Screen)i);
        }
        /// <summary>
        /// Convert index to direction.Screen
        /// </summary>
        /// <param name="index">The index to be converted</param>
        /// <returns>Returns Direction.screen from index converted</returns>
        public static Screen IndexToDirectionScreen(int index)
        {
            return (Screen)index;
        }
        /// <summary>
        /// Convert Direction.Screen to index
        /// </summary>
        /// <param name="side">The Direction.screen to be converted</param>
        /// <returns>Returns index from Direction.screen converted</returns>
        public static int DirectionScreenToIndex(Screen side)
        {
            return (int)side;
        }
    }
}