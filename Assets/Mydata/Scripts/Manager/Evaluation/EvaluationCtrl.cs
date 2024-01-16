using UnityEngine;

public class EvaluationCtrl : MyMonoBehavior, IMission
{
    [SerializeField] private static EvaluationCtrl instance;
    public static EvaluationCtrl Instance => instance;

    protected float maxCurrentValuation = 100f;
    public float MaxCurrentValuation => maxCurrentValuation;
    protected float currentEvaluation = 50f;
    public float CurrentEvaluation => currentEvaluation;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        currentEvaluation = 50f;
        ObserverMission.Instance.AddObserver(this);
    }
    public virtual void SetCurrentValuation(float value)
    {
        currentEvaluation += value;
        if (currentEvaluation > 100) { currentEvaluation = 100; }
        else if (currentEvaluation < 0) { currentEvaluation = 0; }
        else return;
    }

    public float EvaluationDevil()
    {
        return maxCurrentValuation - currentEvaluation;
    }

    public void CompletedMission()
    {
        this.currentEvaluation = 50f;
    }
}
