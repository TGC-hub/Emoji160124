using UnityEngine.UI;

public class ImageHumanMissionRight : BaseImage
{
    protected virtual void FixedUpdate()
    {
        if(MissionManager.Instance.NumberTarget == 2)
        {
            this.image.sprite = MissionManager.Instance.TargetRight.GetComponent<Image>().sprite;
            this.transform.gameObject.SetActive(true);
        }
        else
        {
            this.transform.gameObject.SetActive(false);
        }
    }
}
