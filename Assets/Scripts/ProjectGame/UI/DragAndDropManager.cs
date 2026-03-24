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
            if (_draggingSlotUI == null) return;

            InventoryUI fromUI = _draggingSlotUI.InventoryUI;
            InventoryUI toUI   = targetSlotUI.InventoryUI;

            int fromIndex = _draggingSlotUI.GetSlotIndex();
            int toIndex   = targetSlotUI.GetSlotIndex();

            Inventory fromInventory = fromUI.Inventory;
            Inventory toInventory   = toUI.Inventory;

            CreatureSlot fromSlot = fromInventory.GetSlot(fromIndex);
            CreatureSlot toSlot   = toInventory.GetSlot(toIndex);

            if (fromSlot == null || toSlot == null || fromSlot.IsEmpty) 
            {
                ClearDraggingData();
                return;
            }

            Creature creatureToMove = fromSlot.Creature;

            // === Логика переноса ===
            if (!toSlot.IsEmpty)
            {
                // Своп
                Creature temp = toSlot.Creature;
                toSlot.Set(creatureToMove);
                fromSlot.Set(temp);
            }
            else
            {
                // Простой перенос
                fromSlot.Clear();
                toSlot.Set(creatureToMove);
            }

            // === Самое важное ===
            fromInventory.RaiseInventoryChanged();   // или fromUI.RefreshSlots();
            toInventory.RaiseInventoryChanged();     // или toUI.RefreshSlots();

            // Если у тебя есть отдельный "список существ" в Combiner — обнови его здесь тоже

            ClearDraggingData();
        }
            
        private void ClearDraggingData()
        {
            _draggingSlotUI = null;
            _draggingSlotData = null;
        }
    }
}