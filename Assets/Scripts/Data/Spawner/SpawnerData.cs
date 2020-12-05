using UnityEngine;

namespace Data.Spawner
{
    [CreateAssetMenu(fileName = "SpawnerData", menuName = "Data/Spawner/SpawnerData")]
    public class SpawnerData : BaseData
    {
        public PlanetData planetData;
        public RockData[] rocks;

        public int pointsOnPlanetCount = 0;
        public int rockElementsCount = 0;

        public BusyZoneData[] busyZones;
    }
}