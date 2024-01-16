using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MyMonoBehavior
{
    [SerializeField] protected float delay = 0.5f;

    [SerializeField] protected float timer = 0;

    protected override void Start()
    {
        base.Start();
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    protected virtual bool CountDown()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }
}
