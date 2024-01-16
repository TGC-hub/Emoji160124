using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MyMonoBehavior
{
    public Transform playerCamera; 
    public float rotationSpeed = 5f;
    [SerializeField] protected Transform gun;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (playerCamera != null) return;
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    void Update()
    {
        RotateGun();
    }

    void RotateGun()
    {
        Vector3 lookDirection = playerCamera.forward;

        Quaternion targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
