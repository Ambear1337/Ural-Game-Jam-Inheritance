using Sisus.Init;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace ProjectGame.UI
{
    [Service(FindFromScene = true)]
    public class DragAndDropManager: MonoBehaviour 
    {
        [SerializeField]
        private Image _dragIcon;
            
        private CreatureSlotUI _draggingSlotUI;
        private CreatureSlot _draggingSlotData;
            
        private RectTransform _dragIconRect;

        private void Start()
        {
            // Подготовка иконки перетаскивания
            _dragIconRect = _dragIcon.GetComponent<RectTransform>();
            _dragIcon.gameObject.SetActive(false);
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
        }

        public void HandleDrop(CreatureSlotUI targetSlotUI, PointerEventData eventData)
        {
            int fromIndex;
            int toIndex;
                
            CreatureSlot fromSlot;
            CreatureSlot toSlot;

            InventoryUI fromInventory = _draggingSlotUI.InventoryUI;
            InventoryUI toInventory = targetSlotUI.InventoryUI;
                
            fromIndex = _draggingSlotUI.GetSlotIndex();
            toIndex = targetSlotUI.GetSlotIndex();

            fromSlot = fromInventory.Inventory.GetSlot(fromIndex);
            toSlot = toInventory.Inventory.GetSlot(toIndex);
            
            if (fromSlot == null || toSlot == null) return;

            var fromCreatureTemp = fromSlot.Creature;
            var toCreatureTemp = toSlot.Creature;
                
            // Если дропаем на занятый слот
            if (!toSlot.IsEmpty)
            {
                fromSlot.Set(toCreatureTemp);
                toSlot.Set(fromCreatureTemp);
            }
            else
            {
                fromSlot.Clear();
                toSlot.Set(fromCreatureTemp);
            }

            fromInventory.RefreshSlots();
            toInventory.RefreshSlots();
            ClearDraggingData();
        }
            
        private void ClearDraggingData()
        {
            _draggingSlotUI = null;
            _draggingSlotData = null;
        }
    }
}