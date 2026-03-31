using ProjectGame.Buttons;
using ProjectGame.Combinations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectGame.UI
{
    public class CombineButton: MenuButtonLeftClickBase
    {
        [SerializeField] private Combiner _combiner;
        
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
            _combiner.TryCombineCreatures();
        }
    }
}
