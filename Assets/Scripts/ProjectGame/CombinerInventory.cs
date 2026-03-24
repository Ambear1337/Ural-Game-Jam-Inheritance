using ProjectGame.UI;
using UnityEngine;

namespace ProjectGame
{
    public class CombinerInventory: Inventory
    {
        public bool PlaceInResultSlot(Creature creature)
        {
            if (creature == null) return false;
    
            // Предполагаем, что результат всегда в слоте 2
            if (_slots.Count < 3) return false;

            CreatureSlot resultSlot = _slots[2];
            if (!resultSlot.IsEmpty) return false;

            resultSlot.Set(creature);
            RaiseInventoryChanged();        // или OnInventoryChanged?.Invoke();
            return true;
        }
    }
}