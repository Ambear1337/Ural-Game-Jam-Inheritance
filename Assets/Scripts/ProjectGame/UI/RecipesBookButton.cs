using ProjectGame.Buttons;
using ProjectGame.UI;
using UnityEngine;

public class RecipesBookButton: MenuButtonLeftClickBase
{
    [SerializeField] private RecipesBookUI _recipesBookUI;
    
    protected override void FireEvent()
    {
        _recipesBookUI.ToggleRecipesBook();
    }
}
