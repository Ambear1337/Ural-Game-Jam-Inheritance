using UnityEngine;

namespace ProjectGame.UI
{
    public class PlayerInventoryUI: InventoryUI
    {
        [SerializeField] private Vector2 _openedPosition;
        [SerializeField] private Vector2 _closedPosition;

        private bool _isOpen;

        public override void ToggleInventory()
        {
            _rectTransform.anchoredPosition = _isOpen ? _closedPosition : _openedPosition;
            
            _isOpen = !_isOpen;
            
            base.ToggleInventory();
        }
    }
}