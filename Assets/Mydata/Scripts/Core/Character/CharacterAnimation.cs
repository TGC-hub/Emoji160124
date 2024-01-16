using CoreGame;
using System;
using System.Collections;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    [SerializeField] private Animator[] animator;
    [SerializeField] private CharacterBase character;

    protected int movementHash;
    protected int onInteract;
    protected int endGame;
    private int isInteract;
    private int isIntroPhase;
    private Animator curAnimator;

    private int indexModel = 0;
    private bool loadNewModel;
    private void Start() {
        HashStringAnim();
        LoadModel(0);
        EventDefine.LoadNewModel += LoadNewModel;
        EventDefine.NextPhase += LoadModel;
    }

    private void OnDestroy() {
        EventDefine.LoadNewModel -= LoadNewModel;
        EventDefine.NextPhase -= LoadModel;
    }

    private void LoadModel(int level) {
        HideAllModel();
        indexModel = level;
        animator[level].gameObject.SetActive(true);
        curAnimator = animator[level];
        loadNewModel = false;
    }
    private void HideAllModel() {
        foreach (var it in animator) {
            it.gameObject.SetActive(false);
        }
    }

    private void LoadNewModel(TypeEmojiArrow obj) {
        if (gameObject.activeInHierarchy == false || animator.Length < 1) return;
        foreach (var it in animator) {
            it.gameObject.SetActive(false);
        }
        switch (obj) {
            case TypeEmojiArrow.Eat: {
                    //LoadNewModel
                    if (animator.Length < 2) return;
                    LoadModel(1);

                    break;
                }
            case TypeEmojiArrow.Excercise: {
                    if (animator.Length < 3) return;
                    LoadModel(2);
                    //LoadNewModel
                    break;
                }
            default: {
                    return;
                }
        }
        loadNewModel = true;

    }

    private void LoadModel() {
        if (curAnimator == animator[0] || !loadNewModel) return;
        LoadModel(indexModel + 2);
    }

    private void LateUpdate() {
        CheckAnimCharacter(character);
    }

    private void CheckAnimCharacter(CharacterBase character) {
        switch (character.StateCharacter) {
            case StateCharacter.Interact: {
                    curAnimator.SetInteger(endGame, 0);
                    SetState(character.TypeEmoji);
                    break;
                }
            case StateCharacter.Locomotion: {
                    curAnimator.SetInteger(endGame, 0);
                    curAnimator.SetInteger(isIntroPhase, 0);
                    curAnimator.SetBool(isInteract, false);
                    MovementAnim(character.Velocity);
                    break;
                }
            case StateCharacter.EndPhase: {
                    curAnimator.SetBool(isInteract, false);
                    curAnimator.SetInteger(endGame, 1);
                    break;
                }
            case StateCharacter.Intro: {
                    curAnimator.SetInteger(endGame, 0);
                    curAnimator.SetInteger(isIntroPhase, GameController.Instance.CurrentPhase + 1);
                    break;
                }
            default: {
                    Debug.LogError("Out of state character");
                    break;
                }
        }
    }

    private void HashStringAnim() {
        movementHash = Animator.StringToHash("MoveSpeed");
        onInteract = Animator.StringToHash("TypeInteract");
        isInteract = Animator.StringToHash("OnInteract");
        endGame = Animator.StringToHash("EndGame");
        isIntroPhase = Animator.StringToHash("IntroPhase");
    }

    private void MovementAnim(Vector3 velocity) {
        curAnimator.SetFloat(movementHash, velocity.magnitude > 0.25f ? 1 : 0);
    }

    private void SetState(TypeEmojiArrow typeEmoji) {
        curAnimator.SetInteger(onInteract, (int)typeEmoji);
        curAnimator.SetBool(isInteract, true);
    }

}
