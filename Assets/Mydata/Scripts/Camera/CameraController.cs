using Cinemachine;
using CoreGame;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MyMonoBehavior
{
    private static CameraController instance;
    public static CameraController Instance => instance;

    [SerializeField] protected CinemachineVirtualCamera virtualCameraPlayer;
    public CinemachineVirtualCamera VirtualCameraPlayer => virtualCameraPlayer;

    [SerializeField] private CinemachineVirtualCamera virtualCameraEvent;
    [SerializeField] private CinemachineVirtualCamera virtualCameraContent;

    protected bool isStartPhase = true;

    public CinemachineVirtualCamera currentCamera { get; private set; }


    [SerializeField] protected CameraFollowEvent cameraFollowEvent;

    protected bool onEnableCameraContent = true;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCameraFollowEvent();
    }



    protected virtual void LoadCameraFollowEvent()
    {
        if (cameraFollowEvent != null) return;
        cameraFollowEvent = GameObject.FindGameObjectWithTag("CameraFollowEvent").GetComponent<CameraFollowEvent>();

    }

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
        currentCamera = virtualCameraPlayer;
        EventDefine.EndIntro += DisCameraContent;
        EventDefine.NextPhase += SetCameraContent;
    }


    protected override void Start()
    {
        base.Start();
        isStartPhase = true;
        onEnableCameraContent = true;
        virtualCameraPlayer.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventDefine.EndIntro -= DisCameraContent;
        EventDefine.NextPhase -= SetCameraContent;
    }
    private void LateUpdate()
    {
        SetCamera();
        SetCurrentCamera();
    }

    protected virtual void DisCameraContent()
    {
        onEnableCameraContent = false;
        isStartPhase = false;
        OnCameraMain();
        Debug.Log("EndIntro");
    }
    public virtual void SetCameraContent()
    {
        onEnableCameraContent = true;
        isStartPhase = true;
        OnEnableCameraFollowEvent();
        Debug.Log("NextPhase");
    }
    protected virtual void SetCurrentCamera()
    {

        if (virtualCameraEvent.isActiveAndEnabled == true)
        {
            currentCamera = virtualCameraEvent;
        }
        else
        {
            currentCamera = virtualCameraPlayer;
        }
    }

    protected virtual void SetCamera()
    {
        if (cameraFollowEvent.FollowEvent == true)
        {
            if(onEnableCameraContent == false)
            {
                OnEnableCameraFollowEvent();
            }
            else
            {
                if (isStartPhase == false) return;
                isStartPhase = false;
                SetCamIntro();
            }
        }
        else
        {
            InputManager.Instance.lockInput = false;
            OnCameraMain();
        }

    }


    protected virtual void SetCamIntro()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        OnEnableCameraFollowEvent();
        yield return new WaitForSeconds(2f);
        OnCameraContent();
    }

    protected virtual void OnCameraContent()
    {
        virtualCameraContent.gameObject.SetActive(true);
        virtualCameraEvent.gameObject.SetActive(false);
        virtualCameraPlayer.gameObject.SetActive(false);
    }

    protected virtual void OnCameraMain()
    {

        virtualCameraPlayer.gameObject.SetActive(true);
        virtualCameraEvent.gameObject.SetActive(false);
        virtualCameraContent.gameObject.SetActive(false);
    }

    protected virtual void OnEnableCameraFollowEvent()
    {
        virtualCameraPlayer.gameObject.SetActive(false);
        virtualCameraEvent.gameObject.SetActive(true);
        InputManager.Instance.lockInput = true;
    }

    public virtual void SetCameraCurrent()
    {
        currentCamera = virtualCameraPlayer;
        OnCameraMain();
    }
}
