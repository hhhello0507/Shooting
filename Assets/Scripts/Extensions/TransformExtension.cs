using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        public static Vector3 GetDirection(this Transform transform, Transform target)
        {
            return (target.position - transform.position).normalized;
        }
    }
}