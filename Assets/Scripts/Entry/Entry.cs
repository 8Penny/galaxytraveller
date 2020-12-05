using System.Collections.Generic;
using Core;
using Malee.List;
using Managers;
using UnityEngine;

namespace Entry
{
    public class Entry : MonoBehaviour
    {
        [Reorderable] public ManagersList managers;

        [System.Serializable]
        public class ManagersList : ReorderableArray<BaseManager>
        {
        }

        private void Awake()
        {
            foreach (var managerBase in managers)
            {
                GameCore.Add(managerBase);
            }
        }
    }
}