using ProjectGame.Buttons;
using UnityEngine;

namespace ProjectGame.UI
{
    public class TypesRecipesButton: MenuButtonLeftClickBase
    {
        [SerializeField] private RecipesBookUI _recipesBookUI;
        
        protected override void FireEvent()
        {
            _recipesBookUI.ActivateTypesPanel();
        }
    }
}