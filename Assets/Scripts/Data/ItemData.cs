using UnityEngine;

namespace Data {
    [CreateAssetMenu(fileName = "ItemData", menuName = "Data/ItemData")]
    public class ItemData : BaseData {
        public string id;
        public int count;
    }
}