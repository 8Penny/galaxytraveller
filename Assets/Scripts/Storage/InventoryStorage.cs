using System.Collections.Generic;
using Items;

namespace Storage
{
    [System.Serializable]
    public class InventoryStorage : Storage {
        public bool canAddItem => _items.Count < 10;
        public List<Item> items => _items;
        private List<Item> _items = new List<Item>();

        public bool TryAddNewItem(Item item) {
            if (TryStackItem(item)) {
                return true;
            }
            if (!canAddItem) {
                return false;
            }
            _items.Add(item);
            return true;
        }

        private bool TryStackItem(Item item) {
            var sameItems = _items.FindAll(s => s.id == item.id && s.count < s.maxCount);
            if (sameItems.Count == 0) {
                return false;
            }
            foreach (var sameItem in sameItems) {
                var emptySpace = sameItem.maxCount - sameItem.count;
                if (item.count > emptySpace) {
                    item.SetNewCount(item.count - emptySpace);
                    sameItem.SetNewCount(sameItem.maxCount);
                }
                else {
                    sameItem.SetNewCount(sameItem.count + item.count);
                    item.SetNewCount(0);
                    return true;
                }
            }
            return false;
        }
    }
}
