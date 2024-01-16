using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBackHome : BaseButton
{
    protected override void OnClick()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            UIController.Instance.OnEnableHomeUI();
        }
    }
}
