using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MyMonoBehavior
{
    private static UIController instance;
    public static UIController Instance => instance;

    [SerializeField] protected InGameAppear inGameUI;
    public InGameAppear InGameUI => inGameUI;

    [SerializeField] protected HomeAppear homeUI;
    public HomeAppear HomeUI => homeUI;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInGameUI();
        LoadHomeUI();
    }

    protected virtual void LoadInGameUI()
    {
        if (inGameUI != null) return;
        inGameUI = transform.GetComponentInChildren<InGameAppear>();
    }

    protected virtual void LoadHomeUI()
    {
        if(homeUI != null) return;
        homeUI = transform.GetComponentInChildren<HomeAppear>();
    }

    protected override void Start()
    {
        base.Start();
        OnEnableHomeUI();
    }


    public virtual void OnEnableInGameUI()
    {
        inGameUI.Appear();
        homeUI.Hide();
    }

    public virtual void OnEnableHomeUI()
    {
        inGameUI.Hide();
        homeUI.Appear();
    }
}
