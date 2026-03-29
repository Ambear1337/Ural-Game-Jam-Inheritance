using System;
using UnityEngine;
using Sisus.Init;
using System.Collections.Generic;

namespace ProjectGame.Combinations
{
    [Service(AddressableKey="RecipeService", Instantiate = true)]
    public class RecipeService: MonoBehaviour<RecipesBook>
    {
        [SerializeField] private List<CreatureTypeRecipeTemplate> _typeCombinations;
        [SerializeField] private List<CreatureElementRecipeTemplate> _elementCombinations;

        private RecipesBook _recipesBook;
        
        protected override void Init(RecipesBook argument)
        {
            _recipesBook = argument;
        }

        public CreatureType TryGetTypeResult(CreatureType type1, CreatureType type2)
        {
            CreatureType result = CreatureType.None;
            
            for (int i = 0; i < _typeCombinations.Count; i++)
            {
                if ((_typeCombinations[i].Type1 != type1 || _typeCombinations[i].Type2 != type2) &&
                    (_typeCombinations[i].Type1 != type2 || _typeCombinations[i].Type2 != type1)) continue;
                
                result = _typeCombinations[i].Result;
                AddNewTypeRecipeToBook(_typeCombinations[i]);
                return result;
            }

            return result;
        }

        public CreatureElement TryGetElementResult(CreatureElement element1, CreatureElement element2)
        {
            CreatureElement result = CreatureElement.None;
            
            for (int i = 0; i < _elementCombinations.Count; i++)
            {
                if (_elementCombinations[i].Element1 == element1 && _elementCombinations[i].Element2 == element2 || _elementCombinations[i].Element2 == element1 && _elementCombinations[i].Element1 == element2)
                {
                    result = _elementCombinations[i].Result;
                    AddNewElementRecipeToBook(_elementCombinations[i]);
                    return result;
                }
            }

            return result;
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