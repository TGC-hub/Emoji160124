using System.Collections;
using UnityEngine;

public class UITaskCtrl : MyMonoBehavior, IMission
{
    protected bool onFinishMission = true;
    [SerializeField] protected float delay = 7f;

    [SerializeField] protected float timer = 0;

    protected override void Start()
    {
        base.Start();
        timer = 0;
        ObserverMission.Instance.AddObserver(this);
    }
    protected virtual void FixedUpdate()
    {
        //FollowResultMission();
        //ReturnResualtMission();
    }

    protected virtual void ReturnResualtMission()
    {
        DoingMission(ObserverHappy.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
        DoingMission(ObserverAngry.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
        DoingMission(ObserverCry.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
        DoingMission(ObserverVomiting.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
        DoingMission(ObserverClown.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
    }

    protected virtual void FollowResultMission()
    {
        switch (MissionManager.Instance.MissionValue) 
        {
            case 0:
                DoingMission(ObserverHappy.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
                break;
            case 1:
                DoingMission(ObserverAngry.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
                break;
            case 2:
                DoingMission(ObserverCry.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
                break;
            case 3:
                DoingMission(ObserverVomiting.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
                break;
            case 4:
                DoingMission(ObserverClown.Instance.GetCountInListName(MissionManager.Instance.TargetLeft.name, MissionManager.Instance.TargetRight.name));
                break;
        }
    }

    protected virtual void DoingMission(float numberOfList)
    {
        if (numberOfList < 1) return;
        if (MissionManager.Instance.NumberTarget < 1) return;
        else if (MissionManager.Instance.NumberTarget == 1)
        {
            FinishMission();
        }
        else
        {
            if (numberOfList < 2) return;
            FinishMission();
        }
    }

    public virtual void FinishMission()
    {
        if (onFinishMission == false) return;
        if (CountDown() == false) return;
        onFinishMission = false;
        ObserverWinLose.Instance.PlayerWin();
        onFinishMission = true;
        timer = 0;
        //StartCoroutine(WaitingForComplete());
    }

    IEnumerator WaitingForComplete()
    {
        yield return new WaitForSeconds(7.0f);
        ObserverWinLose.Instance.PlayerWin();
        onFinishMission = true;
    }


    protected virtual bool CountDown()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }

    public void CompletedMission()
    {
        timer = 0;
    }
}
