using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectGame.UI
{
    public class CreatureSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
    {
        [SerializeField] private Image backgroundImage;  // Фон слота (например, рамка)
        [SerializeField] private Image itemImage;        // Иконка предмета
        
        private bool _isSelected = false;
        private CreatureSlot _slotData;
        private int _slotIndex;
        private InventoryUI _inventoryUI;

        // Для drag&drop
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;
        
        // ReSharper disable Unity.PerformanceAnalysis
        private void Awake()
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

        public void RefreshSlot(CreatureSlot slot)
        {
            _slotData = slot;

            if (_slotData == null || _slotData.IsEmpty)
            {
                itemImage.enabled = false;
            }
            else
            {
                itemImage.sprite = _slotData.Creature.CreatureDescription.CreatureSprite;
                itemImage.enabled = true;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (_inventoryUI.SelectedSlot != null) _inventoryUI.SelectedSlot._isSelected = false;

                _inventoryUI.SetSelectedSlot(this);
                _isSelected = true;
            }
        }

        // Начало перетаскивания
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_slotData == null || _slotData.IsEmpty) return;

            _canvasGroup.blocksRaycasts = false;
            _inventoryUI.StartDragging(this, _slotData);
        }

        // Во время перетаскивания
        public void OnDrag(PointerEventData eventData)
        {
            if (_slotData == null || _slotData.IsEmpty) return;

            _inventoryUI.Drag(eventData);
        }

        // Отпускание предмета
        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;

            _inventoryUI.EndDragging(eventData);
        }

        // Обработка дропа предмета на этот слот
        public void OnDrop(PointerEventData eventData)
        {
            _inventoryUI.HandleDrop(this, eventData);
        }

        public int GetSlotIndex()
        {
            return _slotIndex;
        }
    }
}