using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : MyMonoBehavior
{
    [SerializeField] protected IconCtrl iconCtrl;
    public IconCtrl IconCtrl => iconCtrl;

    [SerializeField] protected SingleEffectCtrl singleEffectCtrl;
    public SingleEffectCtrl SingleEffectCtrl => singleEffectCtrl;

    [SerializeField] protected DoubleEffectCtrl doubleEffectCtrl;
    public DoubleEffectCtrl DoubleEffectCtrl => doubleEffectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadIconCtrl();
        LoadEffectCtrl();
        LoadDoubleEffect();
    }
    protected virtual void LoadDoubleEffect()
    {
        if (doubleEffectCtrl != null) return;
        doubleEffectCtrl = transform.GetComponentInChildren<DoubleEffectCtrl>();
    }
    protected virtual void LoadEffectCtrl()
    {
        if (singleEffectCtrl != null) return;
        singleEffectCtrl = transform.GetComponentInChildren<SingleEffectCtrl>();
    }
    protected virtual void LoadIconCtrl()
    {
        if (iconCtrl != null) return;
        iconCtrl = transform.GetComponentInChildren<IconCtrl>();
    }

}
