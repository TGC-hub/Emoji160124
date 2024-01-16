using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraZoomIn : MonoBehaviour
{
    protected Vector3 startPos;
    protected Vector3 tarPos;
    [SerializeField] protected Vector3 offset;

    protected float moveSpeed = 15f;
    private void Start()
    {
        startPos = transform.localPosition;
        tarPos = transform.localPosition + offset;
    }

    protected virtual void FixedUpdate()
    {
        if (InputManager.Instance.EnableZoom == true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, tarPos.z), moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, transform.localPosition.y, startPos.z), moveSpeed * Time.deltaTime);
        }
    }
}
