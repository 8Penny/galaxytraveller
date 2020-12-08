using Storage;
using UnityEngine;

namespace Data.PlayerStats
{
    [CreateAssetMenu(fileName = "PlayerStatsData", menuName = "Data/PlayerStats/PlayerStatsData")]
    public class PlayerStatsData : BaseData
    {
        public uint points;
        public float energy;
        public float health;
        public uint rang;

        public Vector3 position;
        public float rotation;

        public InventoryStorage inventory = new InventoryStorage();
    }
}