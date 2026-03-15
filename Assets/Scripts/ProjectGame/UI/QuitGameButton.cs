using ProjectGame.Buttons;
using UnityEngine;

public class QuitGameButton: MenuButtonLeftClickBase
{
    protected override void FireEvent()
    {
        Application.Quit();
    }
}
