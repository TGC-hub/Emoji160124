
using UnityEngine;

public class BeQueenCharacter : Character {
    public override void OnInteract(TypeEmojiArrow emojiArrow) {
        switch (emojiArrow) {
            case TypeEmojiArrow.Vote: {
                GameController.Instance.SetInteractAI(TypeEmojiArrow.Unvote);
                break;
            }
        }
        base.OnInteract(emojiArrow);
    }

    protected override void EndPhase() {
        base.EndPhase();
    }

    protected override void ShowEffect(TypeEmojiArrow emojiArrow)
    {
        base.ShowEffect(emojiArrow);
        //characterCtrl.IconCtrl.SpawnEffects(emojiArrow);
        characterCtrl.SingleEffectCtrl.SpawnEffects(emojiArrow);
    }

    protected override void InteractAfterMove() {
        transform.forward = -Vector3.forward;
        switch (typeEmoji) {
            case TypeEmojiArrow.Excercise: {
                    break;
                }
            case TypeEmojiArrow.Eat: {
                    break;
                }
            case TypeEmojiArrow.Sing: {
                    break;
                }
            case TypeEmojiArrow.Cry: {
                    break;
                }
            case TypeEmojiArrow.Vote: {
                    break;
                }
            case TypeEmojiArrow.Unvote: {
                    break;
                }
            default: {
                    Debug.Log("Out of logic emoji");
                    break;
                }
        }
        base.InteractAfterMove();
    }

    protected override void StartPhase() {
        base.StartPhase();
        transform.forward = -Vector3.forward;
    }

}
