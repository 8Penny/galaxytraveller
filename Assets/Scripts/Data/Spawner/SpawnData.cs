using UnityEngine;

namespace Data.Spawner
{
    [CreateAssetMenu(fileName = "SpawnData", menuName = "Data/Spawner/SpawnData")]
    public class SpawnData : BaseData
    {
        public string id;
        public GameObject prefab;
        public int weight;
        public int type;
    }
}