using CoreGame;
using UnityEngine;

public class CameraContent : MyMonoBehavior
{
    [SerializeField] protected Vector3 posContent;
    [SerializeField] protected Vector3 offset;

    protected override void Awake()
    {
        base.Awake();
        EventDefine.NextPhase += StartGetPos;
    }

    private void OnDestroy()
    {
        EventDefine.NextPhase -= StartGetPos;
    }

    protected virtual void StartGetPos()
    {
        posContent = GameController.Instance.ContentBGPos.position;
        Vector3 pos = posContent + offset;
        transform.position = pos;
    }
}
