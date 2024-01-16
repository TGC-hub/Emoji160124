using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRare : BaseButton
{
    protected override void OnClick()
    {
        ShowContent.Instance.Show("Rare");
    }
}
