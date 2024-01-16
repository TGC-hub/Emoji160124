using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLevelMap : BaseText
{
    protected virtual void FixedUpdate()
    {
        int levelMap = PlayerPrefs.GetInt("SelectedHouse") + 1;
        this.text.SetText("Map " + levelMap);
    }
}
