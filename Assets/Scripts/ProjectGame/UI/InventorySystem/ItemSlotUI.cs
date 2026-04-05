using System;
using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectGame.UI.InventorySystem
{
    public class ItemSlotUI: MonoBehaviour<DragAndDropManager, Shop>, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        [SerializeField] protected Image itemImage;
        
        private bool _isSelected = false;
        protected ItemSlot _slotData;
        private int _slotIndex;
        private InventoryUI _fromInventoryUI;
        public InventoryUI FromInventoryUI => _fromInventoryUI;
        private InventoryUI _inventoryUI;
        public InventoryUI InventoryUI => _inventoryUI;

        // Для drag&drop
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;
        
        private DragAndDropManager _dragAndDropManager;
        protected Shop _shop;
        
        protected override void Init(DragAndDropManager argument, Shop shop)
        {
            _dragAndDropManager = argument;
            _shop = shop;
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        protected override void OnAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetSlotIndex(int index)
        {
            _slotIndex = index;
        }

        public void SetInventoryUI(InventoryUI inventoryUI)
        {
            _inventoryUI = inventoryUI;
        }

        public virtual void RefreshSlot(ItemSlot slot)
        {
            _slotData = slot;

            if (_slotData == null || _slotData.IsEmpty)
            {
                itemImage.enabled = false;
            }
            else
            {
                itemImage.sprite = _slotData.Item.ItemSprite;
                itemImage.enabled = true;
            }
        }

        // Начало перетаскивания
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_slotData == null || _slotData.IsEmpty) return;

            _fromInventoryUI = _inventoryUI;
            
            _canvasGroup.blocksRaycasts = false;
            _dragAndDropManager.StartDragging(this, _slotData);
        }

        // Во время перетаскивания
        public void OnDrag(PointerEventData eventData)
        {
            if (_slotData == null || _slotData.IsEmpty) return;

            _dragAndDropManager.Drag(eventData);
        }

        // Отпускание предмета
        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;

            _dragAndDropManager.EndDragging(eventData);
        }

        // Обработка дропа предмета на этот слот
        public virtual void OnDrop(PointerEventData eventData)
        {
            _dragAndDropManager.HandleDrop(this, eventData);
        }

        public int GetSlotIndex()
        {
            return _slotIndex;
        }

        protected virtual void OnDestroy()
        {
            
        }
    }
}