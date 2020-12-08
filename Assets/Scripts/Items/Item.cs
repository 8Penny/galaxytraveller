using System;
using Data;
using UnityEngine;

namespace Items
{
    [Serializable]
    public class Item
    {
        public string id => _id;
        private string _id;
        public int count => _count;
        private int _count;

        public int maxCount => _maxCount;
        private int _maxCount = 10;

        public Item(string iId, int iCount) {
            _id = iId;
            _count = iCount;
        }
        public Item(ItemData item) {
            _id = item.id;
            _count = item.count;
        }

        public void SetNewCount(int c) {
            _count = c;
        }
    }
}