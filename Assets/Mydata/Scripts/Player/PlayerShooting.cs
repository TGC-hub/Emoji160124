using CoreGame;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooting : MyMonoBehavior, IWinLose, IMission
{
    protected bool onStartShoot = false;

    protected override void Start()
    {
        base.Start();
        onStartShoot = false;
        ObserverWinLose.Instance.AddObserver(this);
        EventDefine.EndIntro += CanShoot;
        InputManager.Instance.lockInput = true;
    }

    private void OnDestroy()
    {
        EventDefine.EndIntro -= CanShoot;
    }
    protected virtual void Update()
    {
        SettingShoot();
    }
        
    protected virtual void CanShoot()
    {
        onStartShoot = true;
        InputManager.Instance.lockInput = false;
    }

    protected virtual void SettingShoot()
    {
        if (InputManager.Instance.lockInput == true) return;
        if (InputManager.Instance.IsPointerOverUIObjects()) return;
        if (onStartShoot == false) return;
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    protected virtual void Shooting()
    {
        Vector3 pos = transform.position;
        Quaternion rot = Camera.main.transform.rotation;
        string prefab = PlayerPrefs.GetString("SelectEmoji");
        Transform obj = ArrowSpawner.Instance.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    public void SendMessYouWin()
    {
        onStartShoot = false;
    }

    public void SendMessYouLoss()
    {
    }

    public void CompletedMission()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        onStartShoot = true;
    }
}
