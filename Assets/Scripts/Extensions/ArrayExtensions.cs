using UnityEngine;

namespace Extensions
{
    public static class ArrayExtensions
    {
        public static T Choice<T>(this T[] array)
        {
            var index = Random.Range(0, array.Length);
            return array[index];
        }
    }
}