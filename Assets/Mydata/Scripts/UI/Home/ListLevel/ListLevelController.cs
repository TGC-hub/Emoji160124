using CoreGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListLevelController : MyMonoBehavior
{
    [SerializeField] protected List<Transform> level;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.level.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.level.Add(prefab);
            }
        }

    }

    protected override void OnEnable()
    {
        base.OnEnable();
        ShowPosLevel();
    }
    protected virtual void ShowPosLevel()
    {
        int dem = 1;
        foreach (Transform prefab in level)
        {
            if(dem == UserData.CurrrentLevel)
            {
                prefab.GetComponent<Image>().color = Color.red;
            }
            dem++;
        }
    }
}
