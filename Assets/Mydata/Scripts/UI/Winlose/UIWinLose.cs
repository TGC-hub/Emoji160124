using CoreGame;
using UnityEngine;

public class UIWinLose : MyMonoBehavior, IWinLose, IMission
{
    [SerializeField] protected LoseAppear panelLose;
    [SerializeField] protected WinAppear panelWin;

    protected override void Start()
    {
        base.Start();
        ObserverWinLose.Instance.AddObserver(this);
        EventDefine.EndGame += SendMessYouWin;
        
    }


    private void OnDestroy()
    {
        EventDefine.EndGame -= SendMessYouWin;
    }

    public void SendMessYouLoss()
    {
        panelLose.Appear();
    }

    public void SendMessYouWin()
    {
        panelWin.Appear();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPanelLose();
        LoadPanelWin();
    }

    protected virtual void LoadPanelLose()
    {
        if (panelLose != null) return;
        panelLose = transform.Find("PanelLose").GetComponent<LoseAppear>();
    }
    protected virtual void LoadPanelWin()
    {
        if (panelWin != null) return;
        panelWin = transform.Find("PanelWin").GetComponent<WinAppear>();
    }

    public void CompletedMission()
    {
        panelWin.Hide();
    }
}
