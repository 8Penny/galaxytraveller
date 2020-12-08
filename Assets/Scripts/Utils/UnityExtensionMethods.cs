using UnityEngine;

namespace Utils {
    public static class UnityExtensionMethods {
        public static void TrySetActive(this GameObject gameObject, bool value)
        {
            if (gameObject.activeSelf == value) {
                return;
            }
            gameObject.SetActive(value);
        }
    }
}