using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonOpenSetting : BaseButton
{
    [SerializeField] protected PanelSettingAppear panelSetting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPanelSetting();
    }

    protected virtual void LoadPanelSetting()
    {
        if (panelSetting != null) return;
        panelSetting = transform.parent.GetComponentInChildren<PanelSettingAppear>();
    }

    protected override void OnClick()
    {
        panelSetting.gameObject.SetActive(true);
        //ObserverEventGamePlay.Instance.PauseGamePlay();
    }

    protected virtual void FixedUpdate()
    {
        if (transform.position.z > 1f) return;
    }

}
