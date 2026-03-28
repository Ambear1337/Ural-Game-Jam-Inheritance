using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame.Combinations
{
    public class RecipesBook: MonoBehaviour
    {
        private List<CreatureTypeRecipeTemplate> _knownTypeRecipes;
        private List<CreatureElementRecipeTemplate> _knownElementRecipes;

        private void Awake()
        {
            
        }

        public void AddNewRecipe(CreatureTypeRecipeTemplate typeRecipe, CreatureElementRecipeTemplate elementRecipe)
        {
            if (!CheckIfTypeRecipeIsAlreadyKnown(typeRecipe))
            {
                _knownTypeRecipes.Add(typeRecipe);
            }

            if (!CheckIfElementRecipeIsAlreadyKnown(elementRecipe))
            {
                _knownElementRecipes.Add(elementRecipe);
            }
        }

        private bool CheckIfTypeRecipeIsAlreadyKnown(CreatureTypeRecipeTemplate typeRecipe)
        {
            for (int i = 0; i < _knownTypeRecipes.Capacity; i++)
            {
                if (_knownTypeRecipes[i] == typeRecipe)
                {
                    return true;
                }
            }
            
            return false;
        }

        private bool CheckIfElementRecipeIsAlreadyKnown(CreatureElementRecipeTemplate elementRecipe)
        {
            for (int i = 0; i < _knownElementRecipes.Capacity; i++)
            {
                if (_knownElementRecipes[i] == elementRecipe)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}