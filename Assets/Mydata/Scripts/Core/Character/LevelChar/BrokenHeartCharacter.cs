using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenHeartCharacter : Character {

    protected override void StartPhase() {
        base.StartPhase();
        var dir = transform.forward;
        if (GameController.Instance.TargetCharacter != null) {
            var target = GameController.Instance.TargetCharacter.transform.position;
            if (target != null) dir = target - transform.position;
            this.transform.forward = dir;
        }
    }

    public override void OnInteract(TypeEmojiArrow emojiArrow) {
        switch (emojiArrow) {
            case TypeEmojiArrow.Angry: {
                    //LoadNewModel
                    GameController.Instance.SetInteractAI(emojiArrow);
                    break;
                }
            case TypeEmojiArrow.Cry: {
                    //LoadNewModel
                    break;
                }
            case TypeEmojiArrow.Excercise: {
                    break;
                }
            case TypeEmojiArrow.Happy: {
                    break;
                }
            default: {
                    Debug.Log("Out of logic emoji");
                    break;
                }
        }
        base.OnInteract(emojiArrow);
    }

    protected override void ShowIcon(TypeEmojiArrow emojiArrow) {
        base.ShowIcon(emojiArrow);
        characterCtrl.IconCtrl.SpawnEffects(emojiArrow);
    }

    protected override void ShowEffect(TypeEmojiArrow emojiArrow) {
        base.ShowEffect(emojiArrow);
        characterCtrl.SingleEffectCtrl.SpawnEffects(emojiArrow);
    }


    protected override void InteractAfterMove() {
        base.InteractAfterMove();
        var target = GameController.Instance.TargetCharacter;
        if (target != null) transform.LookAt(target.transform.position);
    }

}
