using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHomeStart : BaseButton
{
    protected override void OnClick()
    {
        GameController.Instance.StartPhase(GameController.Instance.CurrentPhase);
        UIController.Instance.OnEnableInGameUI();
        CameraController.Instance.SetCameraContent();
    }
}
