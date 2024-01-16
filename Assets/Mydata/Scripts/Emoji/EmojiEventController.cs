using UnityEngine;
using UnityEngine.UI;

public class EmojiEventController : MyMonoBehavior
{
    [SerializeField] protected Image imageEmojiEvent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadImageEmojiEvent();
    }

    protected virtual void LoadImageEmojiEvent()
    {
        if (imageEmojiEvent != null) return;
        imageEmojiEvent = transform.GetComponent<Image>();  
    }


}
