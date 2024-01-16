using CoreGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTextLevel : BaseText
{
    protected override void OnEnable()
    {
        base.OnEnable();
        text.SetText("Level " + UserData.CurrrentLevel.ToString());
    }
}
