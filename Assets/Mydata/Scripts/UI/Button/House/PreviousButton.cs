using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousButton : BaseButton
{
    [SerializeField] protected MapCtrl selectHouse;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSelectCharacter();
    }

    protected virtual void LoadSelectCharacter()
    {
        if (selectHouse != null) { return; }
        selectHouse = GameObject.FindGameObjectWithTag("MapHouse").GetComponent<MapCtrl>();
    }
    protected override void OnClick()
    {
        if (selectHouse.Current == 0) { return; }
        selectHouse.YourSelection(-1);
    }
}
