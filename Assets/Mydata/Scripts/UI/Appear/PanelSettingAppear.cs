using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSettingAppear : BaseAppear
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Appear();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        this.Hide();
    }

}
