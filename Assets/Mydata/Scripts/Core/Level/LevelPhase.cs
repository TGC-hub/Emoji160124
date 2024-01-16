using UnityEngine;

public enum TypeLevelInteract {
    SingleInteract,
    DoubleInteract
}

public class LevelPhase : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform[] mainTargetPosition;
    [SerializeField] private Transform aiTargetPos;
    [SerializeField] private AICharacter targetCharacter;
    [SerializeField] private TypeEmojiArrow[] typeEmojiList;
    [SerializeField] private Transform contentBackgroundPos;

    [SerializeField] private TypeLevelInteract typeInteract;

    public Transform StartPos => startPos;
    public Transform ContentBackground => contentBackgroundPos;
    public Transform[] MainTargetPosition => mainTargetPosition;
    public Transform AITargetPosition => aiTargetPos;
    public CharacterBase TargetCharacter => targetCharacter;
    public TypeEmojiArrow[] AllEmojiInPhase => typeEmojiList;
    public TypeLevelInteract TypeInteract => typeInteract;

    public bool SelectEmojiBetter(TypeEmojiArrow emojiSelect) {
        foreach (var it in typeEmojiList) {
            if (it != emojiSelect && (int)it > (int)emojiSelect) return false;
        }
        return true;
    }


    public TypeEmojiArrow GetOtherEmoji(TypeEmojiArrow emojiSelect) {
        foreach (var it in typeEmojiList) {
            if (it != emojiSelect) return it;
        }
        return default;
    }
}
