using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShop : BaseButton
{
    [SerializeField] protected UIShop shopUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShop();
    }

    protected virtual void LoadShop()
    {
        if (shopUI != null) return;
        shopUI = transform.parent.GetComponentInChildren<UIShop>();
    }
    protected override void OnClick()
    {
        shopUI.gameObject.SetActive(true);
    }
}
