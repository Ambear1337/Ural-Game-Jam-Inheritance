using System;
using Sisus.Init;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ProjectGame.Combinations
{
    [Service(FindFromScene = true)]
    public class Combiner: MonoBehaviour<RecipeService>
    {
        [SerializeField]
        private CombinerInventory _combinerInventory;
        
        private Creature _creature1;
        private Creature _creature2;
        private Creature _resultCreature;
        
        public Creature ResultCreature => _resultCreature;
        
        private RecipeService _recipeService;
        
        protected override void Init(RecipeService argument)
        {
            _recipeService = argument;
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
            _creature1 = _combinerInventory.Slots[0].Creature;
            _creature2 = _combinerInventory.Slots[1].Creature;
            _resultCreature = _combinerInventory.Slots[2].Creature;
        }

        public void TryCombineCreatures()
        {
            if (_creature1 == null || _creature2 == null || _resultCreature != null) return;
            
            CreatureType newCreatureType = _recipeService.TryGetTypeResult(_creature1.Type, _creature2.Type);
            CreatureElement newCreatureElement = _recipeService.TryGetElementResult(_creature1.Element, _creature2.Element);
            int newCreatureSize = ((_creature1.Size.CurrentValue + _creature2.Size.CurrentValue) / 2);
            int newCreatureIntelligence = ((_creature1.Intelligence.CurrentValue + _creature2.Intelligence.CurrentValue) / 2);
            int newCreatureAgression = ((_creature1.Aggression.CurrentValue + _creature2.Aggression.CurrentValue) / 2);

            
        }
    }
}