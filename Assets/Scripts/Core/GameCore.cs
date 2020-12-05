using System;
using System.Collections.Generic;
using Interfaces;
using Managers;

namespace Core
{
    public class GameCore : Singleton<GameCore>
    {
        private Dictionary<Type, object> _managers = new Dictionary<Type, object>();


        public static void Add(object obj)
        {
            var shadow = obj;
            var manager = shadow as BaseManager;

            if (manager != null)
            {
                shadow = Instantiate(manager);
            }
            else
            {
                return;
            }

            instance._managers.Add(obj.GetType(), shadow);

            (shadow as IAwake)?.OnAwake();
        }


        public static T Get<T>()
        {
            if (instance == null)
            {
                return default(T);
            }
            instance._managers.TryGetValue(typeof(T), out var manager);
            return (T) manager;
        }


        public void ClearScene()
        {
        }
    }
}