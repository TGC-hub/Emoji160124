using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowContent : MyMonoBehavior
{
    private static ShowContent instance;
    public static ShowContent Instance => instance;
    [SerializeField] private List<Transform> contentShow;

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
        if (this.contentShow.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.contentShow.Add(prefab);
            }
            this.HidePrefabs();
        }

    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.contentShow)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual void Show(string name)
    {
        foreach(Transform t in contentShow)
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

    protected virtual void ShowRandom()
    {
        Show("Common");
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ShowRandom();
    }
}
