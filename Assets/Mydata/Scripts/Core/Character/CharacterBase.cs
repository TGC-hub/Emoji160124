using CoreGame;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : ACollector<Arrow> {
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] protected CharacterCtrl characterCtrl;
    public CharacterCtrl CharacterCtrl => characterCtrl;
    #region Getter
    public Vector3 Velocity => rigid.velocity;
    public StateCharacter StateCharacter => stateCharacter;
    public TypeEmojiArrow TypeEmoji => typeEmoji;
    #endregion

    protected StateCharacter stateCharacter;
    protected TypeEmojiArrow typeEmoji;
    protected Coroutine cMove;


    protected virtual void Awake() {
        EventDefine.NextPhase += StartPhase;
    }


    protected virtual void OnDestroy() {
        EventDefine.NextPhase -= StartPhase;
    }

    public virtual void MoveTo(Vector3 position) {
        if (cMove != null) StopCoroutine(cMove);
        OnInteract();
        cMove = StartCoroutine(IEMove(position, null));
    }
    public virtual void MoveTo(TypeEmojiArrow emojiArrow, Vector3 position) {
        if (cMove != null) StopCoroutine(cMove);
        typeEmoji = emojiArrow;
        PreloadInteractive(emojiArrow);
        OnInteract();
        cMove = StartCoroutine(IEMove(position , null));
    }
    public virtual void MoveTo(TypeEmojiArrow emojiArrow, Vector3 position, Action callback) {
        if (cMove != null) StopCoroutine(cMove);
        typeEmoji = emojiArrow;
        PreloadInteractive(emojiArrow);
        OnInteract();
        cMove = StartCoroutine(IEMove(position, callback));
    }


    protected virtual IEnumerator IEMove(Vector3 position, Action callBack) {
        var dir = (position - transform.position).normalized;
        stateCharacter = StateCharacter.Locomotion;
        transform.forward = dir;
        rigid.velocity = Vector3.zero;
        while (Vector3.Distance(position, transform.position) > 0.1f) {
            rigid.velocity = dir * Time.fixedDeltaTime * 50f;
            yield return null;
        }
        rigid.velocity = Vector3.zero;
        transform.position = position;
        InteractAfterMove();
        callBack?.Invoke();
    }

    protected virtual void ShowEffect(TypeEmojiArrow emojiArrow) { }
    protected virtual void ShowIcon(TypeEmojiArrow emojiArrow) { }

    public virtual void OnInteract(TypeEmojiArrow emojiArrow) {
        typeEmoji = emojiArrow;
        ShowEffect(typeEmoji);
    }

    protected virtual void OnInteract() {
        OnInteract(typeEmoji);
    }
    protected override void OnInteract(Arrow target) {
        DisableInteract();
        GameController.Instance.InteractCharacter(this, target.TypeEmoji);
        ShowIcon(target.TypeEmoji);
    }

    protected virtual void InteractAfterMove() { 
        stateCharacter = StateCharacter.Interact;    
    }
 
    protected abstract void PreloadInteractive(TypeEmojiArrow emojiArrow);

    protected abstract void StartPhase();
    public virtual void ResetState() {  }
}
