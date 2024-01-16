using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEpic : BaseButton
{
    protected override void OnClick()
    {
        ShowContent.Instance.Show("Epic");
    }
}
