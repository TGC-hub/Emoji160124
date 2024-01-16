using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ButtonNewGame : BaseButton
{
    [SerializeField] protected SaveLevel saveLevel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSaveLevel();
    }

    protected virtual void LoadSaveLevel()
    {
        if (saveLevel != null) return;
        saveLevel = Resources.Load<SaveLevel>("SaveLoad/Level/SaveLoadLevel");
    }
    protected override void OnClick()
    {
        saveLevel.level = 1;
        ObserverStart.Instance.PlayerStartGame();
    }
}
