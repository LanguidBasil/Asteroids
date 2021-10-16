using UnityEngine;

namespace Project.Tools
{
    public static class Trigonometry
    {
        public static Vector2 RadiansToVector2(float zRadians)
        {
            return new Vector2(Mathf.Cos(zRadians), Mathf.Sin(zRadians));
        }

        /// <summary>
        /// Converts degree in normal system to direction
        /// </summary>
        public static Vector2 NormalDegreeToVector2(float zDegree)
        {
            return RadiansToVector2(zDegree * Mathf.Deg2Rad);
        }

        /// <summary>
        /// Converts degree in unity system to direction
        /// </summary>
        public static Vector2 UnityDegreeToVector2(float zDegree)
        {
            return RadiansToVector2(UnityDegreeToNormal(zDegree) * Mathf.Deg2Rad);
        }

        /// <summary>
        /// Converts angle in degrees from unity to normal system
        /// </summary>
        public static float UnityDegreeToNormal(float degree)
        {
            return (degree + 90) % 360;
        }
    }
}
