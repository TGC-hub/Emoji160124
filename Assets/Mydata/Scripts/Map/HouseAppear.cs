using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseAppear : BaseAppear
{
    protected override void OnEnable()
    {
        Appear();
    }

    protected override void OnDisable()
    {
        Hide();
    }
}
