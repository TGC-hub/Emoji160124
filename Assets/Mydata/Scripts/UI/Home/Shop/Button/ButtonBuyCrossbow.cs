using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonBuyCrossbow : BaseButton
{
    [SerializeField] protected TextMeshProUGUI _textMeshPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTextButton();
    }

    protected virtual void LoadTextButton()
    {
        if (_textMeshPro != null) return;
        _textMeshPro = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    protected override void OnClick()
    {
        _textMeshPro.SetText("Select");
        CrossbowCtrlIngame.Instance.Show(transform.name);
        //PlayerPrefs.SetString("SelectCrossbow", transform.name);
    }
}
