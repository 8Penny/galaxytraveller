using System.Collections.Generic;
using Core;
using Managers;
using UnityEngine;

namespace Entry
{
    public class Entry : MonoBehaviour
    {
        public List<ManagerBase> managers = new List<ManagerBase>();


        private void Awake()
        {
            foreach (var managerBase in managers)
            {
                GameCore.Add(managerBase);
            }
        }
    }
}