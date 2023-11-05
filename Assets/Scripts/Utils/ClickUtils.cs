using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Utils
{
    public static class ClickUtils
    {
        public static void ChangeClicksInObjectHierarchy(Transform root, bool value)
        {
            TryChangeClicksInObject(root, value);
            for (var i = 0; i < root.childCount; i++)
            {
                var child = root.GetChild(i);
                ChangeClicksInObjectHierarchy(child, value);
            }
        }

        private static void TryChangeClicksInObject(Component selectedObject, bool value)
        {
            var uiBehaviour = selectedObject.GetComponent<Graphic>();
            if (uiBehaviour == null)
            {
                return;
            }

            uiBehaviour.raycastTarget = value;
        }
    }
}