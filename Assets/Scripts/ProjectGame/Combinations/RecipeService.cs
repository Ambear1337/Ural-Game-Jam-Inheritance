using System;
using UnityEngine;
using Sisus.Init;
using System.Collections.Generic;

namespace ProjectGame.Combinations
{
    [Service(AddressableKey="RecipeService", Instantiate = true)]
    public class RecipeService: MonoBehaviour
    {
        [SerializeField] private List<CreatureTypeRecipeTemplate> _typeCombinations;
        [SerializeField] private List<CreatureElementRecipeTemplate> _elementCombinations;

        public CreatureType TryGetTypeResult(CreatureType type1, CreatureType type2)
        {
            CreatureType result = CreatureType.None;
            
            for (int i = 0; i < _typeCombinations.Count; i++)
            {
                if ((_typeCombinations[i].Type1 != type1 || _typeCombinations[i].Type2 != type2) &&
                    (_typeCombinations[i].Type1 != type2 || _typeCombinations[i].Type2 != type1)) continue;
                
                result = _typeCombinations[i].Result;
                return result;
            }

            return result;
        }

        public CreatureElement TryGetElementResult(CreatureElement element1, CreatureElement element2)
        {
            CreatureElement result = CreatureElement.None;
            
            for (int i = 0; i < _typeCombinations.Count; i++)
            {
                if ((_elementCombinations[i].Element1 != element1 || _elementCombinations[i].Element2 != element2) &&
                    (_elementCombinations[i].Element1 != element2 || _elementCombinations[i].Element2 != element1)) continue;
                
                result = _elementCombinations[i].Result;
                return result;
            }

            return result;
        }
    }
}