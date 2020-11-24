using System.Collections.Generic;
using Objects;
using Storage;
using Utils;

namespace Core
{
    [System.Serializable]
    public class Save
    {
        public List<EnvironmentElement> homePlanetElements = new List<EnvironmentElement>();
        public InventoryStorage playerInventory = new InventoryStorage();

        public uint playerPoints;
        public float playerEnergy;
        public float playerHealth;
        public uint playerRang;

        public SerializableVector3 playerPosition;
        public float playerRotation;
    }
}