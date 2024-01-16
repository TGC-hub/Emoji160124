
using UnityEngine;

public class ButtonContinueLevel : BaseButton
{
    protected override void OnClick()
    {
        ObserverStart.Instance.PlayerStartGame();
    }
}
