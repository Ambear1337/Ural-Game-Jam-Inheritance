using ProjectGame.Buttons;
using UnityEngine;

public class QuestsPanelButton: MenuButtonLeftClickBase
{
    [SerializeField] private GameObject _questsPanel;
    private bool _isOpen;
    
    protected override void FireEvent()
    {
        _questsPanel.SetActive(!_isOpen);
        _isOpen = !_isOpen;
    }
}
