
using System.Collections.Generic;
using UnityEngine;

public class UIGamePlayAppear : BaseAppear
{
    [SerializeField] protected List<Transform> listUI;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.listUI.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.listUI.Add(prefab);
            }
        }
    }

    protected virtual void FixedUpdate()
    {
        if(GameController.Instance.IsPlayZoomCameraEvent == true)
        {
            foreach (Transform prefab in this.listUI)
            {
                prefab.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform prefab in this.listUI)
            {
                prefab.gameObject.SetActive(true);
            }
        }
    }

}
