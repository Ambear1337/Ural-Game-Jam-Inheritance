using System;
using System.Collections.Generic;
using Sisus.Init;
using UnityEngine;

namespace ProjectGame.Combinations
{
    [Service(Instantiate = true)]
    public class RecipesBook: MonoBehaviour
    {
        private List<CreatureTypeRecipeTemplate> _knownTypeRecipes = new List<CreatureTypeRecipeTemplate>();
        public List<CreatureTypeRecipeTemplate> KnownTypeRecipes => _knownTypeRecipes;
        private List<CreatureElementRecipeTemplate> _knownElementRecipes = new List<CreatureElementRecipeTemplate>();
        public List<CreatureElementRecipeTemplate> KnownElementRecipes => _knownElementRecipes;

        public void AddNewTypeRecipe(CreatureTypeRecipeTemplate typeRecipe)
        {
            if (!CheckIfTypeRecipeIsAlreadyKnown(typeRecipe))
            {
                _knownTypeRecipes.Add(typeRecipe);
            }
        }

        public void AddNewElementRecipe(CreatureElementRecipeTemplate elementRecipe)
        {
            if (!CheckIfElementRecipeIsAlreadyKnown(elementRecipe))
            {
                _knownElementRecipes.Add(elementRecipe);
            }
        }

        private bool CheckIfTypeRecipeIsAlreadyKnown(CreatureTypeRecipeTemplate typeRecipe)
        {
            for (int i = 0; i < _knownTypeRecipes.Count; i++)
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
            for (int i = 0; i < _knownElementRecipes.Count; i++)
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