using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectGame.UI
{
    public class CreatureSlotUI : MonoBehaviour<DragAndDropManager, Shop>, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
    {
        [SerializeField] private Image backgroundImage;  // Фон слота (например, рамка)
        [SerializeField] private Image itemImage;
        [SerializeField] private Image elementImage;// Иконка предмета
        
        private bool _isSelected = false;
        protected CreatureSlot _slotData;
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

        public void RefreshSlot(CreatureSlot slot)
        {
            _slotData = slot;

            if (_slotData == null || _slotData.IsEmpty)
            {
                itemImage.enabled = false;
                elementImage.enabled = false;
            }
            else
            {
                itemImage.sprite = _slotData.Creature.CreatureDescription.CreatureSprite;
                elementImage.sprite = _slotData.Creature.ElementDescription.CreatureElementSprite;
                itemImage.enabled = true;
                elementImage.enabled = true;
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
    }
}