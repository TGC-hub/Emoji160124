using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelectCrossbow : BaseButton
{
    protected override void OnClick()
    {
        CrossbowCtrl.Instance.Show(transform.name);
        Debug.Log(transform.name);
    }
}
