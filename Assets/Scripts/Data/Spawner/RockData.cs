using UnityEngine;

namespace Data.Spawner
{
    [CreateAssetMenu(fileName = "RockData", menuName = "Data/Spawner/RockData")]
    public class RockData : BaseData
    {
        public int id;
        public GameObject prefab;
        public int weight;
    }
}