using CoreGame;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image fadeTop;
    [SerializeField] private Image fadeBottom;

    private void Awake() {
        EventDefine.EndPhase += Hide;
        EventDefine.NextPhase += UnHide;
    }

    private void OnDestroy() {
        EventDefine.NextPhase -= UnHide;
        EventDefine.EndPhase -= Hide;
    }

    private void UnHide() {
        StartCoroutine(IEHide(false));
    }

    public void Hide() {
        StartCoroutine(IEHide(true));
    }

    private IEnumerator IEHide(bool hide) {
        float target = hide ? 1 : 0;
        float value = 1 - target;

        fadeTop.fillAmount = value;
        fadeBottom.fillAmount = value;

        var time = 0f;
        while (time < 2) {
            value += Time.deltaTime * (hide ? 1 : -1) / 2;
            fadeTop.fillAmount = value;
            fadeBottom.fillAmount = value;
            time += Time.deltaTime;
            yield return null;
        }
        fadeTop.fillAmount = target;
        fadeBottom.fillAmount = target;
    }

}
