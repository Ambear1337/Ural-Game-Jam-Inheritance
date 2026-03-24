namespace ProjectGame
{
    public class CombinerInventory: Inventory
    {
        public override bool AddItem(Creature creature)
        {
            if (creature == null || !Slots[2].IsEmpty) return false;
        
            _slots[2].Add(creature);

            InvokeOnInventoryChanged();
            return true;
        }
    }
}