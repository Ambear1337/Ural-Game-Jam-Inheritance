using ProjectGame.UI.InventorySystem;

namespace ProjectGame.Shop
{
    public class ShopCell
    {
        private Item _item;
        public Item Item => _item;
        
        public void SetupShopCell(Item item)
        {
            _item = item;
        }
    }
}