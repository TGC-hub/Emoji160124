using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCommon : BaseButton
{
    protected override void OnClick()
    {
        ShowContent.Instance.Show("Common");
    }
}
