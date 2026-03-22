using ProjectGame.Buttons;
using UnityEngine;

namespace ProjectGame.UI
{
    public class InventoryButton: MenuButtonLeftClickBase
    {
        [SerializeField] private InventoryUI _inventoryUI;
    
        protected override void FireEvent()
        {
            _inventoryUI.ToggleInventory();
        }
    }
}
