using ProjectGame.UI.InventorySystem;
using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace ProjectGame.UI
{
    public class InventoryUI : MonoBehaviour<DragAndDropManager>
    {
        [SerializeField] protected RectTransform _rectTransform;
        
        [SerializeField]
        private ItemSlotUI[] _slotUIs;
        
        private ItemSlotUI _selectedSlot;
        public ItemSlotUI SelectedSlot => _selectedSlot;

        [SerializeField]
        private Inventory _inventory;

        public Inventory Inventory => _inventory;
        
        private ItemSlotUI _draggingSlotUI;
        private ItemSlot _draggingSlotData;
        
        private RectTransform _dragIconRect;
        private DragAndDropManager _dragAndDropManager;
        
        protected override void Init(DragAndDropManager argument)
        {
            _dragAndDropManager = argument;
        }

        private void OnEnable()
        {
            _inventory.OnInventoryChanged += RefreshSlots;
        }

        private void OnDisable()
        {
            _inventory.OnInventoryChanged -= RefreshSlots;
        }

        private void Start()
        {
            InitializeSlots();
        }
        
        public virtual void ToggleInventory()
        {
            RefreshSlots();
        }

        public void SetSelectedSlot(ItemSlotUI slotUI)
        {
            _selectedSlot = slotUI;
        }

        private void InitializeSlots()
        {
            for (int i = 0; i < _inventory.MaxSlots; i++)
            {
                _slotUIs[i].SetSlotIndex(i);
                _slotUIs[i].SetInventoryUI(this);
            }
            
            RefreshSlots();
        }

        public void RefreshSlots()
        {
            for (int i = 0; i < _slotUIs.Length; i++)
            {
                var slot = _inventory.GetSlot(i);
                _slotUIs[i].RefreshSlot(slot);
            }
        }
    }
}