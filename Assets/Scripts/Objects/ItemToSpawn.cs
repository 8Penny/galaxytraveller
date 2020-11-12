using System;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public struct ItemToSpawn
    {
        public GameObject prefab;
        public int weight;
    }
}