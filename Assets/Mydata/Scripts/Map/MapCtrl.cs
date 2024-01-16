using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MyMonoBehavior
{
    [SerializeField] private List<Transform> mapHouse;
    public List<Transform> mapHouseList => mapHouse;    
    private int current = 0;
    public int Current => current;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCharacter();
    }

    protected virtual void LoadCharacter()
    {
        if (this.mapHouse.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.mapHouse.Add(prefab);
            }
            this.HidePrefabs();
        }

    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.mapHouse)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected override void Start()
    {
        if (PlayerPrefs.HasKey("SelectedHouse"))
        {
            SelectedCharacter(PlayerPrefs.GetInt("SelectedHouse"));
        }
        else
        {
            SelectedCharacter(0);
        }
    }
    protected virtual void SelectedCharacter(int index)
    {
        for (int i = 0; i < mapHouse.Count; i++)
        {
            mapHouse[i].gameObject.SetActive(false);
            mapHouse[index].gameObject.SetActive(true);
            PlayerPrefs.SetInt("SelectedHouse", index);
        }
    }

    public virtual void YourSelection(int yourIndex)
    {
        current += yourIndex;
        SelectedCharacter(current);
    }
}
