
using UnityEngine.UI;

public class ImageHumanMissionLeft : BaseImage
{

    protected virtual void FixedUpdate()
    {
        this.image.sprite = MissionManager.Instance.TargetLeft.GetComponent<Image>().sprite;
    }
}
