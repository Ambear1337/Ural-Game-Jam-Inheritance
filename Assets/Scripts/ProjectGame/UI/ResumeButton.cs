using ProjectGame;
using ProjectGame.Buttons;
using UnityEngine;

public class ResumeButton: MenuButtonLeftClickBase
{
    [SerializeField] private GameObject _menuPanel;
    
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
        
        _menuPanel.SetActive(false);
    }
}
