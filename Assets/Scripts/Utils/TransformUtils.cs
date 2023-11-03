using UnityEngine;

namespace Utils
{
    public static class TransformUtils
    {
        public static void DestroyChildren(this Transform transform)
        {
            for (var t = transform.childCount - 1; t >= 0; t--)
            {
                Object.Destroy(transform.GetChild(t).gameObject);
            }
        }
    }
}