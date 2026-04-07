using System.Collections.Generic;
using ProjectGame.Creatures;
using ProjectGame.UI.InventorySystem;
using UnityEngine;

namespace ProjectGame.UI
{
    public class CreatureSlotUI : ItemSlotUI
    {
        [SerializeField] private List<CreatureElement> _elements;
        
        private static readonly int ElementID = Shader.PropertyToID("ElementID");
        private static readonly int MainTexture = Shader.PropertyToID("MainTexture");
        
        private Material _cachedMaterial; // Кэшируем экземпляр

        protected override void OnAwake()
        {
            base.OnAwake();
            // Создаём уникальный материал для этого слота при старте
            if (itemImage != null && itemImage.material != null)
            {
                _cachedMaterial = Instantiate(itemImage.material);
                itemImage.material = _cachedMaterial;
            }
        }

        public override void RefreshSlot(ItemSlot slot)
        {
            base.RefreshSlot(slot);
            
            if (_slotData == null || _slotData.IsEmpty) return;

            // Убеждаемся, что материал существует
            if (_cachedMaterial == null && itemImage != null)
            {
                _cachedMaterial = Instantiate(itemImage.material);
                itemImage.material = _cachedMaterial;
            }

            int currentElementIndex = 40;
            for (int i = 0; i < _elements.Count; i++)
            {
                if (_slotData.Item is Creature creature && _elements[i] == creature.Element)
                {
                    currentElementIndex = i + 1;
                    break; // Нашли нужный элемент - выходим
                }
            }
            
            // Используем кэшированный материал
            _cachedMaterial.SetFloat(ElementID, currentElementIndex);
            _cachedMaterial.SetTexture(MainTexture, _slotData.Item.ItemSprite.texture);
            
            // Убеждаемся, что Image.color не портит альфу
            if (itemImage.color.a < 0.99f)
                itemImage.color = Color.white;
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            // Важно: очищаем созданный материал
            if (_cachedMaterial != null)
                Destroy(_cachedMaterial);
        }
    }
}