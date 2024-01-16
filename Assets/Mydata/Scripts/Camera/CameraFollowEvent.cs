using UnityEngine;

public class CameraFollowEvent : MyMonoBehavior
{
    [SerializeField] protected float followSpeed = 5.0f;
    [SerializeField] protected Vector3 offset;

    private bool followEvent = false;
    public bool FollowEvent => followEvent;

/*    [SerializeField] protected Transform cameraFollowEvent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCameraFollowEvent();
    }

    protected virtual void LoadCameraFollowEvent()
    {
        if (cameraFollowEvent != null) return;
        cameraFollowEvent = GameObject.FindGameObjectWithTag("CameraFollowEvent").GetComponent<Transform>();

    }*/

    protected virtual void LateUpdate()
    {
        GetPosCharacter();
    }

    protected virtual void GetPosCharacter()
    {
        if (GameController.Instance.IsPlayZoomCameraEvent == false) { followEvent = false; }
        else
        {
            OnActiveFollowEvent(GameController.Instance.MainCharacter.transform.position);
        }
        
    }

    protected virtual void OnActiveFollowEvent(Vector3 vector3)
    {
        Vector3 pos = vector3 + offset;
        transform.position = pos;
        followEvent = true;
    }

}
