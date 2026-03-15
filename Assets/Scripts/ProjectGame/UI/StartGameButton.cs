using ProjectGame.Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton: MenuButtonLeftClickBase
{
    protected override void FireEvent()
    {
        SceneManager.LoadScene("GameScene");
    }
}
