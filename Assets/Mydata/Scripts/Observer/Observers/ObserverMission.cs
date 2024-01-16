using System.Collections.Generic;

public class ObserverMission : MyMonoBehavior
{
    private static ObserverMission instance;
    public static ObserverMission Instance => instance;

    private List<IMission> observers = new List<IMission>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IMission observerShot) 
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IMission observerShot) 
    {
        observers.Remove(observerShot);
    }

    public void CompletedMission()
    {
        foreach(IMission observer in observers) 
        {
            observer.CompletedMission();
        }
    }

}
