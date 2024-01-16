using UnityEngine;

public enum TypeEmojiArrow {
    None = 0,
    Unvote = 1,
    Angry = 2,
    Cry = 3,
    Eat = 4,
    Sing = 5,
    Excercise = 6,
    Vote = 7,
    Happy = 8,
}

public class Arrow : AInteractable
{
    public TypeEmojiArrow TypeEmoji => typeEmoji;

    [SerializeField] protected  TypeEmojiArrow typeEmoji;
    [SerializeField] protected float moveSpeed = 20.0f;
    [SerializeField] protected float shotPower = 100f;
    [SerializeField] protected Rigidbody rigid;

    public override void OnInteract(IInteractable other) {
        base.OnInteract(other);
    }

    private void Start() {
        AddForce(Camera.main.transform.forward);
    }
    private void OnEnable() {
        AddForce(Camera.main.transform.forward);
    }

    public virtual void AddForce(Vector3 direction) {
        rigid.velocity = Vector3.zero;
        rigid.AddForce(direction * shotPower);
    }
}
