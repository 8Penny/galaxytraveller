using UnityEngine;

namespace Data.Spawner
{
    [CreateAssetMenu(fileName = "BusyZone", menuName = "Data/Spawner/BusyZone")]
    public class BusyZoneData: BaseData
    {
        public Vector3 position = Vector3.zero;
        public float radius = 0;
    }
}