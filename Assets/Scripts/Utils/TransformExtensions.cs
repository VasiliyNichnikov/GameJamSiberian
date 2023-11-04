using UnityEngine;

namespace Utils
{
    public static class TransformExtensions
    {
        public static void SetMediumAndCentered(this RectTransform transform)
        {
            transform.anchorMin = new Vector2(0.0f, 0.5f);
            transform.anchorMax = new Vector2(1.0f, 0.5f);
            transform.pivot = new Vector2(0.5f, 0.5f);
            transform.ForceUpdateRectTransforms();
        }
        
        public static RectTransform AsRectTransform(this Transform transform) => transform as RectTransform;
    }
}