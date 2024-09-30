using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class ListExtensions
    {
        public static T Choice<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list[index];
        }
    }
}