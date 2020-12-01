using UnityEngine;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static bool isApplicationQuitting;
        private static T _instance;


        public static T instance
        {
            get
            {
                if (isApplicationQuitting)
                    return null;


                if (_instance != null)
                {
                    return _instance;
                }
                _instance = FindObjectOfType<T>();

                if (_instance != null)
                {
                    return _instance;
                }
                
                var singleton = new GameObject(typeof(T).ToString());
                _instance = singleton.AddComponent<T>();
                DontDestroyOnLoad(singleton);

                return _instance;
            }
        }


        public virtual void OnDestroy()
        {
            isApplicationQuitting = true;
        }
    }
}