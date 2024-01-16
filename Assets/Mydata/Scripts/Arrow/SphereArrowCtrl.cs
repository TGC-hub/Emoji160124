using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereArrowCtrl : MyMonoBehavior
{
    [SerializeField] protected static SphereArrowCtrl instance;
    public static SphereArrowCtrl Instance => instance;

    [SerializeField] protected List<Transform> listSphereArrow;
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
        if (this.listSphereArrow.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.listSphereArrow.Add(prefab);
            }
            this.HidePrefabs();
        }

    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.listSphereArrow)
        {
            prefab.gameObject.SetActive(false);
        }
    }


    protected override void Start()
    {
        base.Start();
        ChangeSphereArrow();
    }


    protected virtual void FixedUpdate()
    {
        ChangeSphereArrow();
    }

    public virtual void ChangeSphereArrow()
    {
        foreach (Transform prefab in this.listSphereArrow)
        {
            if(prefab.name == EmojiSelecter.Instance.EmojiSelected.ToString())
            {
                prefab.gameObject.SetActive(true);
            }
            else
            {
                prefab.gameObject.SetActive(false);
            }
        }
    }
}
