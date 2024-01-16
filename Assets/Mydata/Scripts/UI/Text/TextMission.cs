using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMission : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.text.SetText(MissionManager.Instance.MissionName);
    }
}
