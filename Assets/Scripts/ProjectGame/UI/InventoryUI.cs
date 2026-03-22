using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace ProjectGame.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField]
        private Image _dragIcon;

        [SerializeField] private RectTransform _rectTransform;

        [SerializeField] private Vector2 _openedPosition;
        [SerializeField] private Vector2 _closedPosition;
        
        [SerializeField]
        private CreatureSlotUI[] _slotUIs;
        
        private CreatureSlotUI _selectedSlot;
        public CreatureSlotUI SelectedSlot => _selectedSlot;

        [SerializeField]
        private Inventory _inventory;

        private bool isOpen = false;
        
        private CreatureSlotUI _draggingSlotUI;
        private CreatureSlot _draggingSlotData;
        
        private RectTransform _dragIconRect;

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

            // Подготовка иконки перетаскивания
            _dragIconRect = _dragIcon.GetComponent<RectTransform>();
            _dragIcon.gameObject.SetActive(false);
        }

        public void SetSelectedSlot(CreatureSlotUI slotUI)
        {
            _selectedSlot = slotUI;
        }

        public void ToggleInventory()
        {
            _rectTransform.anchoredPosition = isOpen ? _closedPosition : _openedPosition;
            
            isOpen = !isOpen;
            
            RefreshSlots();
        }

        private void MoveUIToOpenedPosition()
        {
            _rectTransform.anchoredPosition = _openedPosition;
        }

        private void MoveUIToClosedPosition()
        {
            _rectTransform.anchoredPosition = _closedPosition;
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

        private void RefreshSlots()
        {
            for (int i = 0; i < _slotUIs.Length; i++)
            {
                var slot = _inventory.GetSlot(i);
                _slotUIs[i].RefreshSlot(slot);
            }
        }
        
        public void StartDragging(CreatureSlotUI slotUI, CreatureSlot slotData)
        {
            _draggingSlotUI = slotUI;
            _draggingSlotData = slotData;

            _dragIcon.sprite = slotData.Creature.CreatureDescription.CreatureSprite;
            _dragIcon.gameObject.SetActive(true);
        }

        // Во время перетаскивания
        public void Drag(PointerEventData eventData)
        {
            // Получаем позицию указателя (мышь или primary touch)
            Vector2 screenPos = Pointer.current.position.ReadValue();

            Vector2 localPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)_dragIcon.transform.parent,
                screenPos,
                null,                           // обычно null, если Canvas в Screen Space – Overlay
                out localPos
            );

            _dragIconRect.anchoredPosition = localPos;
        }

        // Завершаем перетаскивание
        public void EndDragging(PointerEventData eventData)
        {
            // Скрываем и сбрасываем drag icon
            _dragIcon.gameObject.SetActive(false);
            _draggingSlotUI = null;
            _draggingSlotData = null;
        }

        public void HandleDrop(CreatureSlotUI targetSlotUI, PointerEventData eventData)
        {
            if (_draggingSlotUI == null || _draggingSlotData == null) return;

            int fromIndex = _draggingSlotUI.GetSlotIndex();
            int toIndex = targetSlotUI.GetSlotIndex();
            if (fromIndex == toIndex) return;

            CreatureSlot fromSlot = _inventory.GetSlot(fromIndex);
            CreatureSlot toSlot = _inventory.GetSlot(toIndex);

            if (fromSlot == null || toSlot == null) return;

            // Если складываем одинаковые предметы
            if (!toSlot.IsEmpty && fromSlot.Creature == toSlot.Creature)
            {
                var fromCreatureTemp = fromSlot.Creature;
                var toCreatureTemp = toSlot.Creature;
                
                fromSlot.Set(toCreatureTemp);
                toSlot.Set(fromCreatureTemp);
            }

            RefreshSlots();
        }
    }
}