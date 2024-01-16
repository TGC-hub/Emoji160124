using CoreGame;
using System.Collections;
using UnityEngine;


public class GameController : SingletonBehaviour<GameController> {
    [SerializeField] private LevelSpawner levelSpawner;

    private int currentPhase = 0;
    
    private Character mainCharacter;

    private CharacterBase targetCharacter;

    private bool isPlayZoomCamEvent = false;

    private Transform contentBGPos;
    protected override void OnAwake() {
        EventDefine.EndIntro += DisableCamFollow;
    }

    private void DisableCamFollow() {
        ActiveFollowCam(false);
    }

    private void OnDestroy() {
        EventDefine.EndIntro -= DisableCamFollow;
    }

    private void Start() {
        LoadLevel();
    }

    /// <summary>
    /// Fuction to Load new Level
    /// </summary>
    protected virtual void LoadLevel() {
        currentPhase = 0;
        levelSpawner.LoadLevel(UserData.CurrrentLevel);
        mainCharacter = levelSpawner.CurrentLevel.MainChar;
        //StartPhase(currentPhase);
    }


    /// <summary>
    /// Fuction will be call when main character be interacted
    /// </summary>
    /// <param name="emojiArrow"></param>
    public void InteractCharacter(CharacterBase mainChar, TypeEmojiArrow emojiArrow) {
        var curPhaseInfo = levelSpawner.CurrentLevel.GetCurPhase(currentPhase);
        if (curPhaseInfo == null) return;
        var interactMainChar = (bool)(mainChar == (mainCharacter as CharacterBase));
        ActiveFollowCam(true);
        if (interactMainChar) {
            Vector3 positionTarget = curPhaseInfo.MainTargetPosition[curPhaseInfo.SelectEmojiBetter(emojiArrow) ? 1 : 0].position;
            mainCharacter.MoveTo(emojiArrow, positionTarget , () => {
                StartCoroutine(IEInteractCharacter());
                if(curPhaseInfo.TypeInteract == TypeLevelInteract.DoubleInteract){
                    ShowDoubleEffect(curPhaseInfo.MainTargetPosition[curPhaseInfo.SelectEmojiBetter(emojiArrow) ? 1 : 0].position ,emojiArrow);
                }
            });
            return;
        }

        var mainCharEmoji = interactMainChar ? emojiArrow : curPhaseInfo.GetOtherEmoji(emojiArrow);
        targetCharacter?.MoveTo(curPhaseInfo.AITargetPosition.position);
        mainCharacter.MoveTo(mainCharEmoji, curPhaseInfo.MainTargetPosition[0].position, () => {
            StartCoroutine(IEInteractCharacter());
        });
    }

    protected virtual void ShowDoubleEffect(Vector3 posShow, TypeEmojiArrow type)
    {
        mainCharacter.CharacterCtrl.DoubleEffectCtrl.GetPosTarget(posShow);
        mainCharacter.CharacterCtrl.DoubleEffectCtrl.SpawnEffects(type);
    }

    public virtual void SetInteractAI(TypeEmojiArrow emojiArrow) {
        var curPhaseInfo = levelSpawner.CurrentLevel.GetCurPhase(currentPhase);
        if (curPhaseInfo == null) return;
        targetCharacter?.MoveTo(emojiArrow,curPhaseInfo.AITargetPosition.position);
    }

    private IEnumerator IEInteractCharacter() {
        //Await
        yield return new WaitForSeconds(3f);
        EventTrigger.Trigger(EventDefine.EndPhase);
        mainCharacter.ResetState();
        yield return new WaitForSeconds(2.5f);
        ActiveFollowCam(false);
        NextPhase();
    }



    /// <summary>
    /// Fuction to reload some variable or state
    /// </summary>
    protected virtual void ReloadPhase() {

    }

    /// <summary>
    /// Function call to start new phase
    /// </summary>
    public virtual void NextPhase() {
        ReloadPhase();
        if (currentPhase + 1 >= levelSpawner.CurrentLevel.TotalPhase) EventTrigger.Trigger(EventDefine.EndGame);
        else {
            currentPhase += 1;
            StartPhase(currentPhase);
        }
    }

    /// <summary>
    /// Function to get all bot in phase of level
    /// </summary>
    /// <param name="phase"></param>
    private void GetAIChar(int phase) {
        targetCharacter = levelSpawner.CurrentLevel.GetCurPhase(phase)?.TargetCharacter;
    }

    /// <summary>
    /// Fuction call to set state and get variable, state of phase
    /// </summary>
    /// <param name="phase"></param>
    public void StartPhase(int phase) {
        ActiveFollowCam(true);
        mainCharacter.transform.position = levelSpawner.CurrentLevel.GetCurPhase(currentPhase).StartPos.position;
        contentBGPos = levelSpawner.CurrentLevel.GetCurPhase(currentPhase).ContentBackground;
        levelSpawner.CurrentLevel.CheckActivePhase(phase);
        GetAIChar(phase);
        EventTrigger.Trigger(EventDefine.NextPhase);
    }


    /// <summary>
    /// Function to get all emoji in phase to spawn in UI
    /// </summary>
    /// <param name="phase"></param>
    /// <returns></returns>
    protected virtual TypeEmojiArrow[] GetAllEmoji(int phase) {
        return levelSpawner.CurrentLevel.GetCurPhase(phase).AllEmojiInPhase;
    }
    public virtual TypeEmojiArrow[] GetAllEmoji() {
        return levelSpawner.CurrentLevel.GetCurPhase(currentPhase).AllEmojiInPhase;
    }

    public virtual void ActiveFollowCam(bool isActive) {
        isPlayZoomCamEvent = isActive;
    }

    #region Getter

    public Character MainCharacter => mainCharacter;
    public LevelSpawner LevelSpawner => levelSpawner;
    public bool IsPlayZoomCameraEvent => isPlayZoomCamEvent;
    public int CurrentPhase => currentPhase;
    public CharacterBase TargetCharacter => targetCharacter;
    public Transform ContentBGPos => contentBGPos;
    #endregion
}
