using System.Collections.Generic;

public class ObserverMissionSingle : MyMonoBehavior
{
    private static ObserverMissionSingle instance;
    public static ObserverMissionSingle Instance => instance;

    private List<IMissionSingleTarget> observers = new List<IMissionSingleTarget>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IMissionSingleTarget observerShot)
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IMissionSingleTarget observerShot)
    {
        observers.Remove(observerShot);
    }

    public void CompletedMissionSingle()
    {
        foreach (IMissionSingleTarget observer in observers)
        {
            observer.MissionSingleTargetCompleted();
        }
    }

    public void CancleMissionSingle()
    {
        foreach(IMissionSingleTarget observer in observers)
        {
            observer.MissionSingleTargetCanceled();
        }
    }


}
