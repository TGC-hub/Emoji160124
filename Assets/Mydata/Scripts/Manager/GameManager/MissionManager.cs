using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MyMonoBehavior, IMission
{
    private static MissionManager instance;
    public static MissionManager Instance => instance;

    [SerializeField] private Transform emoji;
    public Transform Emoji => emoji;

    [SerializeField] private Transform targetLeft;
    public Transform TargetLeft => targetLeft;

    [SerializeField] private Transform targetRight;
    public Transform TargetRight => targetRight;

    [SerializeField] private int numberTarget = 0;
    public int NumberTarget => numberTarget;

    [SerializeField] protected int missionValue = 99;
    public int MissionValue => missionValue;

    [SerializeField] protected string missionName;
    public string MissionName => missionName;

    [SerializeField] protected List<Transform> listEmoji;
    public List<Transform> ListEmoji => listEmoji;

    protected Mission mission;
    [SerializeField] protected SaveLevel saveLevel;
    public SaveLevel SaveLevel => saveLevel;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        DoingSaveLevel();
    }

    protected virtual void DoingSaveLevel()
    {
        if (saveLevel != null) return;
        saveLevel = Resources.Load<SaveLevel>("SaveLoad/Level/SaveLoadLevel");
    }
    protected virtual void LoadMission()
    {
        mission = Resources.Load<Mission>("Mission/Mission_" + saveLevel.level.ToString());
    }
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        ObserverMission.Instance.AddObserver(this);
        LoadMission();
        SetLevel(mission);
    }
    protected virtual void FixedUpdate()
    {
        if(saveLevel.level < 1) return;
        SetMissionEmoji(emoji);
    }


    protected virtual void SetLevel(Mission mission)
    {
        emoji = mission.emoji;
        targetLeft = mission.targetLeft;
        targetRight = mission.targetRight;
        numberTarget = mission.numberTarget;
        missionName = mission.nameMission;
        listEmoji = mission.listEmoji;
    }

    public void CompletedMission()
    {
        if(saveLevel.level > 4) return;
        saveLevel.level++;
        LoadMission();
        SetLevel(mission);
    }

    protected virtual void SetMissionEmoji(Transform emoji)
    {
        switch (emoji.name)
        {
            case "Happy":
                missionValue = 0;
                break;
            case "Angry":
                missionValue = 1;
                break;
            case "Cry":
                missionValue = 2;
                break;
            case "Vomiting":
                missionValue = 3;
                break;
            case "Clown":
                missionValue = 4;
                break;

        }
    }

    public virtual int GetLevel()
    {
        return saveLevel.level;
    }
}
