using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowCtrl : MyMonoBehavior
{
    private static CrossbowCtrl instance;
    public static CrossbowCtrl Instance => instance;
    [SerializeField] private List<Transform> crossbowShow;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.crossbowShow.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.crossbowShow.Add(prefab);
            }
            this.HidePrefabs();
        }

    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.crossbowShow)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual void Show(string name)
    {
        foreach (Transform t in crossbowShow)
        {
            if (t.name.Contains(name))
            {
                t.gameObject.SetActive(true);
            }
            else
            {
                t.gameObject.SetActive(false);
            }
        }
    }


}
