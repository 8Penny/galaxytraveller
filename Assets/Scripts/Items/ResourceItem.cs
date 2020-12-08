using System;
using Data;

namespace Items
{
    [Serializable]
    public class ResourceItem : Item {
        public ResourceItem(string iId, int iCount) : base(iId, iCount) {
        }
        public ResourceItem(ItemData item) : base(item) {
        }
    }
}