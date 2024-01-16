
using UnityEngine;

public class AICharacter : CharacterBase
{

    protected override void OnInteract(Arrow target) {
        DisableInteract();
        typeEmoji = target.TypeEmoji;
        GameController.Instance.InteractCharacter(this,target.TypeEmoji);
        ShowIcon(target.TypeEmoji);
    }

    protected override void ShowIcon(TypeEmojiArrow emojiArrow)
    {
        characterCtrl.IconCtrl.SpawnEffects(emojiArrow);
    }

    protected override void PreloadInteractive(TypeEmojiArrow emojiArrow) {
        
    }

    protected override void StartPhase() {

    }
}
