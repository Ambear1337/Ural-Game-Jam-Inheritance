using System;
using ProjectGame.Creatures;
using ProjectGame.UI.InventorySystem;
using Sisus.Init;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

namespace ProjectGame.Combinations
{
    [Service(FindFromScene = true)]
    public class Combiner: MonoBehaviour<RecipeService, CreatureSpawner, SoundEffectsSource>
    {
        [SerializeField] private CombinerInventory _combinerInventory;
        [SerializeField] private AudioClip[] _combineAudioEffectClips;
        
        private Creature _creature1;
        private Creature _creature2;
        private Creature _resultCreature;

        private RecipeService _recipeService;
        private CreatureSpawner _spawner;
        private SoundEffectsSource _soundEffectsSource;

        protected override void Init(RecipeService recipeService, CreatureSpawner spawner, SoundEffectsSource soundEffectsSource)
        {
            _recipeService = recipeService;
            _spawner = spawner;
            _soundEffectsSource = soundEffectsSource;
        }

        private void OnEnable()
        {
            _combinerInventory.OnInventoryChanged += UpdateCombinedCreatures;
        }

        private void OnDisable()
        {
            _combinerInventory.OnInventoryChanged -= UpdateCombinedCreatures;
        }

        private void UpdateCombinedCreatures()
        {
            _creature1 = _combinerInventory.Slots[0].Item as Creature;
            _creature2 = _combinerInventory.Slots[1].Item as Creature;
            _resultCreature = _combinerInventory.Slots[2].Item as Creature;
        }

        public void TryCombineCreatures()
        {
            UpdateCombinedCreatures();

            // Проверка, что есть два ингредиента и слот результата пуст
            if (_creature1 == null || _creature2 == null || _resultCreature != null)
            {
                Debug.Log("Combine failed: need two creatures in first two slots and empty result slot.");
                return;
            }

            // Пытаемся получить результат рецепта
            CreatureType newType = _recipeService.TryGetTypeResult(_creature1.Type, _creature2.Type);
            CreatureElement newElement = _recipeService.TryGetElementResult(_creature1.Element, _creature2.Element);
            
            Debug.Log("New type is " + newType + ", new element is " + newElement);

            if (newType == null || newElement == null)
            {
                Debug.LogError("Something is NONE");
                return;
            }

            Debug.Log($"Combining { _creature1.Type } + { _creature2.Type } → {newType}");
            Debug.Log($"Combining { _creature1.Element } + { _creature2.Element } → {newElement}");

            // Вычисляем средние характеристики (можно сделать более сложную формулу позже)
            int newSize = (_creature1.Size.CurrentValue + _creature2.Size.CurrentValue) / 2;
            int newIntelligence = (_creature1.Intelligence.CurrentValue + _creature2.Intelligence.CurrentValue) / 2;
            int newAggression = (_creature1.Aggression.CurrentValue + _creature2.Aggression.CurrentValue) / 2;

            _spawner.ReleaseCreaturesAfterCombine(_creature1, _creature2);
            
            // Спавним новое существо
            _spawner.SpawnCombinedCreature(
                newType,
                newElement,
                newSize,
                newIntelligence,
                newAggression
            );
            
            if (_soundEffectsSource.AudioSource)
            {
                int randomIndex = Random.Range(0, _combineAudioEffectClips.Length);

                if (_combineAudioEffectClips[randomIndex] != null)
                {
                    _soundEffectsSource.AudioSource.PlayOneShot(_combineAudioEffectClips[randomIndex]);
                }
            }
        }

        // Вызывается из CreatureSpawner после спавна
        public void PlaceCombinedCreature(Creature newCreature)
        {
            _combinerInventory.RemoveCreature(0);
            _combinerInventory.RemoveCreature(1);

            if (!_combinerInventory.PlaceInResultSlot(newCreature))
            {
                Debug.LogError("Failed to place result in slot 2!");
            }
        }

        // Опционально: очистка всех слотов
        public void ClearAllSlots()
        {
            for (int i = 0; i < _combinerInventory.Slots.Count; i++)
                _combinerInventory.RemoveCreature(i);

            _combinerInventory.RaiseInventoryChanged();
        }
    }
}