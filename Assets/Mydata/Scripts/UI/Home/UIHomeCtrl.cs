using System.Collections;
using UnityEngine;

public class UIHomeCtrl : MyMonoBehavior, IStart
{
    [SerializeField] protected UIShop shopUI;
    [SerializeField] protected UILoading loadingUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBottomUI();
        LoadCenterUI();
    }

    protected virtual void LoadBottomUI()
    {
        if (shopUI != null) return;
        shopUI = transform.GetComponentInChildren<UIShop>();
    }

    protected virtual void LoadCenterUI()
    {
        if (loadingUI != null) return;
        loadingUI = transform.GetComponentInChildren<UILoading>();
    }

    protected override void Start()
    {
        ObserverStart.Instance.AddObserver(this);
    }

    public void OnStartting()
    {
        StartCoroutine(StartLoading());
    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSeconds(2.0f);
        loadingUI.gameObject.SetActive(true);
    }
}
