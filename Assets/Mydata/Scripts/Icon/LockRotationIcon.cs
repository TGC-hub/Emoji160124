using Cinemachine;
using UnityEngine;

public class LockRotationIcon : MyMonoBehavior
{
    protected CinemachineVirtualCamera cameraToLookAt;

    void Update()
    {
        cameraToLookAt = CameraController.Instance.currentCamera;

        transform.LookAt(cameraToLookAt.transform);
    }
}
