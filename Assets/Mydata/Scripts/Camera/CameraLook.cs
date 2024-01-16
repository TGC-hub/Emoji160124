using UnityEngine;
using UnityEngine.UIElements;

public class CameraLook : MyMonoBehavior
{
    public float rotationSpeedMobile = 20.0f;
    public float rotationSpeedPC = 200.0f;

    [SerializeField] protected float cameraSmooth = 1;
    [SerializeField] protected float lookRightMax;
    [SerializeField] protected float lookRightMin;
    [SerializeField] protected float lookUpMax;
    [SerializeField] protected float lookUpMin;
    protected Quaternion cameraRot;

    protected override void Start()
    {
        base.Start();
        cameraRot = transform.localRotation;
    }

    protected virtual void Update()
    {
        if (InputManager.Instance.lockInput == true) return;
        LockRotationZ();
        CameraRotationLook();
    }

    protected virtual void CameraRotationLook()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                cameraRot.x += - touch.deltaPosition.y * rotationSpeedMobile * Time.deltaTime;
                cameraRot.y += touch.deltaPosition.x * rotationSpeedMobile * Time.deltaTime;

                cameraRot.x = Mathf.Clamp(cameraRot.x,lookRightMin, lookRightMax);
                cameraRot.y = Mathf.Clamp(cameraRot.y, lookUpMin, lookUpMax);

                transform.localRotation = Quaternion.Euler(cameraRot.x,cameraRot.y,cameraRot.z);
            }
        }

/*        if (Input.GetMouseButton(0))
        {
            cameraRot.x += -Input.GetAxis("Mouse Y") * rotationSpeedPC;
            cameraRot.y += Input.GetAxis("Mouse X") * rotationSpeedPC;

            cameraRot.x = Mathf.Clamp(cameraRot.x, lookRightMin, lookRightMax);
            cameraRot.y = Mathf.Clamp(cameraRot.y, lookUpMin, lookUpMax);

            transform.localRotation = Quaternion.Euler(cameraRot.x, cameraRot.y, cameraRot.z);

        }*/
    }

    protected virtual void LockRotationZ()
    {
        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.z = 0f;
        transform.eulerAngles = currentRotation;
    }
/*    protected virtual bool CountDown()
    {
        this.timer += Time.deltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }*/
}
