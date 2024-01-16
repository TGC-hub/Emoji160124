using CoreGame;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public enum StateCharacter {
    Intro,
    Interact,
    Locomotion,
    EndPhase
}

public class Character : CharacterBase
{
    protected override void Awake()
    {
        base.Awake();
        EventDefine.EndIntro += EndIntro;
        EventDefine.EndPhase += EndPhase;
        characterCtrl = GetComponent<CharacterCtrl>();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventDefine.EndPhase -= EndPhase;
        EventDefine.EndIntro -= EndIntro;
    }


    protected override IEnumerator IEMove(Vector3 position, Action callBack) {
        var dir = (position - transform.position).normalized;
        stateCharacter = StateCharacter.Locomotion;
        transform.forward = dir;
        rigid.velocity = Vector3.zero;
        EndInteract();
        while(Vector3.Distance(position, transform.position) > 0.15f) {
            rigid.velocity = dir * Time.fixedDeltaTime * 50f;
            yield return null;
        }
        rigid.velocity = Vector3.zero;
        transform.position = position;
        InteractAfterMove();
        callBack?.Invoke();
    }

    protected virtual void EndPhase() {
        rigid.velocity = Vector3.zero;
        //stateCharacter = StateCharacter.EndPhase;
        if(cMove != null) StopCoroutine(cMove);
        cMove = null;
    }

    protected override void StartPhase() {
        stateCharacter = StateCharacter.Intro;
        DisableInteract();
    }

    private void EndIntro() {
        stateCharacter = StateCharacter.Locomotion;
        EnableInteract();
    }

    protected virtual void EndInteract() { }
    public override void OnInteract(IInteractable other) {
        base.OnInteract(other);
    }
    
    protected override void ShowEffect(TypeEmojiArrow emojiArrow) 
    {

    }

    protected override void ShowIcon(TypeEmojiArrow emojiArrow)
    {
        characterCtrl.IconCtrl.SpawnEffects(emojiArrow);
    }

    protected override void InteractAfterMove() {
        base.InteractAfterMove();
    }

    protected override void PreloadInteractive(TypeEmojiArrow emojiArrow) {

    }

    public override void ResetState() {
        stateCharacter = StateCharacter.Locomotion;
    }
}
