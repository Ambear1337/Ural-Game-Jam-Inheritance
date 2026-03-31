using ProjectGame.Buttons;
using UnityEngine;

namespace ProjectGame.UI
{
    public class TypesRecipesButton: MenuButtonLeftClickBase
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
            _recipesBookUI.ActivateTypesPanel();
        }
    }
}