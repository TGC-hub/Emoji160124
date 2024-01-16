using UnityEngine.UI;

public class ImageEmoji : BaseImage
{
    protected virtual void FixedUpdate()
    {
        this.image.sprite = MissionManager.Instance.Emoji.GetComponent<Image>().sprite;
    }
}
