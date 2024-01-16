using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderDefault : MyMonoBehavior
{
    [SerializeField] protected HumanController humanController;
    [SerializeField] protected List<Transform> obj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHumanCtrl();
        LoadObj();
    }

    protected virtual void LoadObj()
    {
        if (this.obj.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.obj.Add(prefab);
            }
            this.HideObj();
        }

    }

    protected virtual void HideObj()
    {
        foreach (Transform prefab in this.obj)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHumanCtrl()
    {
        if (humanController != null) return;
        humanController = transform.parent.GetComponent<HumanController>();
    }

    protected virtual void FixedUpdate()
    {
        if(humanController.HumanEventChecker.TypeEmoji != 99) 
        {
            foreach(Transform transform in obj)
            {
                transform.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform transform in obj)
            {
                transform.gameObject.SetActive(true); 
            }
        }
    }
}
