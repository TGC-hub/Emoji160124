using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterLevel_5 : MyMonoBehavior
{
    [SerializeField] protected EventCtrl eventCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEventController();
    }

    protected virtual void LoadEventController()
    {
        if (eventCtrl != null) return;
        eventCtrl = transform.parent.parent.GetComponentInChildren<EventCtrl>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowActiveEvent"))
        {
            eventCtrl.ActiveEvent();
        }
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        LoadEventController();
    }
}
