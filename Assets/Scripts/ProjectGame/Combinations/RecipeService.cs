using System;
using UnityEngine;
using Sisus.Init;
using System.Collections.Generic;
using ProjectGame.Creatures;
using Random = UnityEngine.Random;

namespace ProjectGame.Combinations
{
    [Service(AddressableKey="RecipeService", Instantiate = true)]
    public class RecipeService: MonoBehaviour<RecipesBook>
    {
        [SerializeField] private List<CreatureTypeRecipeTemplate> _typeCombinations;
        [SerializeField] private List<CreatureElementRecipeTemplate> _elementCombinations;

        [SerializeField] private List<CreatureType> _creatureTypes;
        [SerializeField] private List<CreatureElement> _creatureElements;
        
        public List<CreatureType> CreatureTypes => _creatureTypes;
        public List<CreatureElement> CreatureElements => _creatureElements;

        private RecipesBook _recipesBook;
        
        protected override void Init(RecipesBook argument)
        {
            _recipesBook = argument;
        }
        
        public CreatureType GetRandomCreatureType()
        {
            int randomIndex = Random.Range(0, _creatureTypes.Count);

            if (_creatureTypes[randomIndex] == null)
            {
                Debug.LogError("Тип существа не найден!");
                return null;
            }

            return _creatureTypes[randomIndex];
        }
        
        public CreatureElement GetRandomCreatureElement()
        {
            int randomIndex = Random.Range(0, _creatureElements.Count);

            if (_creatureElements[randomIndex] == null)
            {
                Debug.LogError("Элемент существа не найден!");
                return null;
            }
        
            return _creatureElements[randomIndex];
        }

        public CreatureType TryGetTypeResult(CreatureType type1, CreatureType type2)
        {
            CreatureType result;
            
            for (int i = 0; i < _typeCombinations.Count; i++)
            {
                if ((_typeCombinations[i].Type1 != type1 || _typeCombinations[i].Type2 != type2) &&
                    (_typeCombinations[i].Type1 != type2 || _typeCombinations[i].Type2 != type1)) continue;
                
                result = _typeCombinations[i].Result;
                AddNewTypeRecipeToBook(_typeCombinations[i]);
                return result;
            }

            return null;
        }

        public CreatureElement TryGetElementResult(CreatureElement element1, CreatureElement element2)
        {
            CreatureElement result;
            
            for (int i = 0; i < _elementCombinations.Count; i++)
            {
                if (_elementCombinations[i].Element1 == element1 && _elementCombinations[i].Element2 == element2 || _elementCombinations[i].Element2 == element1 && _elementCombinations[i].Element1 == element2)
                {
                    result = _elementCombinations[i].Result;
                    AddNewElementRecipeToBook(_elementCombinations[i]);
                    return result;
                }
            }

            return null;
        }

        private void AddNewTypeRecipeToBook(CreatureTypeRecipeTemplate typeRecipe)
        {
            _recipesBook.AddNewTypeRecipe(typeRecipe);
        }

        private void AddNewElementRecipeToBook(CreatureElementRecipeTemplate elementRecipe)
        {
            _recipesBook.AddNewElementRecipe(elementRecipe);
        }
    }
}