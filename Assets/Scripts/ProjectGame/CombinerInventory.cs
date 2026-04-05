using ProjectGame.UI;
using ProjectGame.UI.InventorySystem;
using UnityEngine;

namespace ProjectGame
{
    public class CombinerInventory: Inventory
    {
        public bool PlaceInResultSlot(Item item)
        {
            if (item == null) return false;
    
            // Предполагаем, что результат всегда в слоте 2
            if (_slots.Count < 3) return false;

            ItemSlot resultSlot = _slots[2];
            if (!resultSlot.IsEmpty) return false;

            resultSlot.Set(item);
            RaiseInventoryChanged();        // или OnInventoryChanged?.Invoke();
            return true;
        }
    }
}