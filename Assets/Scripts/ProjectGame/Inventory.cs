using System.Collections.Generic;
using ProjectGame.UI;
using ProjectGame.UI.InventorySystem;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame
{
    public class Inventory: MonoBehaviour
    {
        public delegate void InventoryChanged();
        protected internal event InventoryChanged OnInventoryChanged;
        
        [SerializeField]
        private int _maxSlots;
        public int MaxSlots => _maxSlots;
        
        protected List<ItemSlot> _slots;
        public List<ItemSlot> Slots => _slots;
        
        private void Awake()
        {
            // Инициализируем слоты пустыми, если список пустой или меньше maxSlots
            if (_slots == null)
                _slots = new List<ItemSlot>();

            while (_slots.Count < _maxSlots)
            {
                _slots.Add(new ItemSlot());
            }
        }

        public void SetMaxSlots(int maxSlots)
        {
            _maxSlots = maxSlots;
        }

        public bool GetIsFull()
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                if (_slots[i].IsEmpty) return false;
            }

            return true;
        }

        // Добавить предмет в инвентарь, возвращает true если всё влезло
        public virtual bool AddItem(Item item)
        {
            if (item == null) return false;
        
            for (int i = 0; i < _slots.Count; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    _slots[i].Add(item);

                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }

            return false;
        }

        // Удалить предмет из слота без создания PickupItem
        public void RemoveCreature(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= _slots.Count) return;

            ItemSlot slot = _slots[slotIndex];
            if (slot.IsEmpty) return;

            slot.Clear();
        }

        public ItemSlot GetSlot(int index)
        {
            if (index < 0 || index >= _slots.Count) return null;
            return _slots[index];
        }
        
        protected internal void RaiseInventoryChanged()
        {
            OnInventoryChanged?.Invoke();
        }
    }
}
