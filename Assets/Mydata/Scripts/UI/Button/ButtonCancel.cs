using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCancel : BaseButton
{
    [SerializeField] protected Transform obj;
    protected override void OnClick()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Time.timeScale = 1.0f;
            obj.gameObject.SetActive(false);
        }
    }
}
