using ProjectGame.Buttons;
using UnityEngine;

namespace ProjectGame.UI
{
    public class InventoryButton: MenuButtonLeftClickBase
    {
        [SerializeField] private InventoryUI _inventoryUI;
        private SoundEffectsSource _soundEffectsSource;
    
        protected override void FireEvent()
        {
            if (_audioSource && _soundEffect)
            {
                _audioSource.PlayOneShot(_soundEffect);
            }
            _inventoryUI.ToggleInventory();
        }

        protected override void Init(SoundEffectsSource argument)
        {
            _soundEffectsSource = argument;
            _audioSource = _soundEffectsSource.AudioSource;
        }
    }
}
