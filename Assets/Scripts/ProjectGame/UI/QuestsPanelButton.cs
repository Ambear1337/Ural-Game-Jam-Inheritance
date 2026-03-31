using ProjectGame;
using ProjectGame.Buttons;
using UnityEngine;

public class QuestsPanelButton: MenuButtonLeftClickBase
{
    [SerializeField] private GameObject _questsPanel;
    private bool _isOpen;
    
    private SoundEffectsSource _soundEffectsSource;
        
    protected override void Init(SoundEffectsSource argument)
    {
        _soundEffectsSource = argument;
    }
    
    protected override void FireEvent()
    {
        _questsPanel.SetActive(!_isOpen);
        _isOpen = !_isOpen;
    }
}
