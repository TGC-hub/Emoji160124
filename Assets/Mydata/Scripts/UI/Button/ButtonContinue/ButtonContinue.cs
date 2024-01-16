using CoreGame;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class ButtonContinue : BaseButton
{
    protected override void OnClick()
    {
        UserData.CurrrentLevel++;
        //ObserverMission.Instance.CompletedMission();
        SceneManager.LoadScene(0);
    }
}
