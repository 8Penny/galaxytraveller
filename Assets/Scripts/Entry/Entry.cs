using System.Collections.Generic;
using Core;
using Managers;
using UnityEngine;

namespace Entry
{
    public class Entry : MonoBehaviour
    {
        public List<BaseManager> managers = new List<BaseManager>();


        private void Awake()
        {
            foreach (var managerBase in managers)
            {
                GameCore.Add(managerBase);
            }
        }
    }
}