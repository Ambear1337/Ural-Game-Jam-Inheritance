using UnityEngine.UI;

namespace ProjectGame.UI.InventorySystem
{
    public class ItemSlot
    {
        private Item _item;
        public Item Item => _item;

        public bool IsEmpty => _item == null;

        public void Clear()
        {
            _item = null;
        }

        public void Set(Item newItem)
        {
            _item = newItem;
        }

        public void Add(Item newItem)
        {
            if (IsEmpty)
            {
                Set(newItem);
            }
        }
    }
}