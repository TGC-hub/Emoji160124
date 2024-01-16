using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class EventCtrl : MyMonoBehavior
{
    [SerializeField] protected Transform gameObjectOne;
    [SerializeField] protected Transform gameObjectTwo;
    [SerializeField] protected Transform effect;

    public virtual void ActiveEvent()
    {
        gameObjectOne.gameObject.SetActive(false);
        gameObjectTwo.gameObject.SetActive(true);
        effect.gameObject.SetActive(true);
    }

}
