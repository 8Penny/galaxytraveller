using System;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public struct ItemToSpawn
    {
        public int id;
        public GameObject prefab;
        public int weight;
    }
}