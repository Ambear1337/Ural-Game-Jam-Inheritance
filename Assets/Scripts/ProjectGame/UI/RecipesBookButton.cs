using ProjectGame;
using ProjectGame.Buttons;
using ProjectGame.UI;
using UnityEngine;

public class RecipesBookButton: MenuButtonLeftClickBase
{
    [SerializeField] private RecipesBookUI _recipesBookUI;
    
    private SoundEffectsSource _soundEffectsSource;
        
    protected override void Init(SoundEffectsSource argument)
    {
        _soundEffectsSource = argument;
        _audioSource = _soundEffectsSource.AudioSource;
    }
    
    protected override void FireEvent()
    {
        if (_audioSource && _soundEffect)
        {
            _audioSource.PlayOneShot(_soundEffect);
        }
        _recipesBookUI.ToggleRecipesBook();
    }
}
