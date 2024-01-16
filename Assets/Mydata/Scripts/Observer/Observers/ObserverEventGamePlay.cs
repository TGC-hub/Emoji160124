using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverEventGamePlay : MyMonoBehavior
{
    private static ObserverEventGamePlay instance;
    public static ObserverEventGamePlay Instance => instance;

    private List<IEventGamePlay> observers = new List<IEventGamePlay>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IEventGamePlay observerShot)
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IEventGamePlay observerShot)
    {
        observers.Remove(observerShot);
    }

    public void PauseGamePlay()
    {
        foreach (IEventGamePlay observer in observers)
        {
            observer.PauseGame();
        } 
    }

    public void ContinueGamePlay()
    {
        foreach (IEventGamePlay observer in observers)
        {
            observer.ContinueGame();
        }
    }
}
