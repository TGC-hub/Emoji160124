using UnityEngine;
using UnityEngine.UI;

public class BaseImage : MyMonoBehavior
{
    [Header("Base Image")]
    [SerializeField] protected Image image;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) { return; }
        this.image = transform.GetComponent<Image>();
    }
}
