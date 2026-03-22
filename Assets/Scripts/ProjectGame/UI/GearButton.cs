using ProjectGame.Buttons;
using UnityEngine;

public class GearButton: MenuButtonLeftClickBase
{
    [SerializeField]
    private GameObject _menuPanel;
    
    protected override void FireEvent()
    {
        _menuPanel.SetActive(true);
    }
}
