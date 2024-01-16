using CoreGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDelegate : MonoBehaviour
{
    private void EndIntro() {
        EventTrigger.Trigger(EventDefine.EndIntro);
    }
}
