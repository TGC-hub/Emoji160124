using UnityEngine;

public class HumanAnimation : MyMonoBehavior
{
    [SerializeField] private Animator animator;
    protected int movementHash;
    protected int onTriggerHash;
    protected int typeEmojiHash;
    protected int stateStartHash;
    protected int stateWaitingHash;

    [SerializeField] protected HumanController humanCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHumanMovement();
        LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = transform.GetComponent<Animator>();
    }

    protected virtual void LoadHumanMovement()
    {
        if (humanCtrl != null) return;
        humanCtrl = transform.parent.GetComponent<HumanController>();
    }

    protected override void Start()
    {
        base.Start();
        movementHash = Animator.StringToHash("MoveSpeed");
        onTriggerHash = Animator.StringToHash("OnTriggerArrow");
        typeEmojiHash = Animator.StringToHash("TypeEmoji");
        stateStartHash = Animator.StringToHash("StateStart");
        stateWaitingHash = Animator.StringToHash("OnWaiting");
    }

    protected virtual void Update()
    {
        OnAnimationMovement();
        OnTriggerArrow();
        StartState();
        OnWaitingAnim();
    }

    protected virtual void OnWaitingAnim()
    {
        animator.SetFloat(typeEmojiHash, humanCtrl.HumanEventChecker.TypeEmoji);
    }

    protected virtual void StartState()
    {
        if (humanCtrl.HumanMoveToEvent.OnMoveToEvent == true) return;
        animator.SetFloat(stateStartHash, MissionManager.Instance.GetLevel());
    }

    protected virtual void OnTriggerArrow()
    {
        if(humanCtrl.HumanMoveToEvent.OnMoveToEvent == true)
        {
            animator.SetFloat(movementHash, 1);
            if (humanCtrl.HumanMoveToEvent.Distance <= 1.0f)
            {
                animator.SetBool(onTriggerHash, true);
                animator.SetFloat(typeEmojiHash, humanCtrl.HumanEventChecker.TypeEmoji);
            }
            else
            {
                animator.SetBool(onTriggerHash, false);
            }
        }
        else
        {
            animator.SetFloat(movementHash, 0);
            animator.SetBool(onTriggerHash, false);
        }
    }

    protected virtual void OnAnimationMovement()
    {
        if(humanCtrl.HumanMoveToEvent.OnMoveToEvent == true) 
        {
            if(humanCtrl.HumanMoveToEvent.MoveSpeedToTarget == 0)
            {
                animator.SetFloat(movementHash, 0);
            }
            else
            {
                animator.SetFloat(movementHash, 1);
            }
        }
        else
        {
/*            if (humanCtrl.HumanMoveDefault.MoveSpeed == 0)
            {
                animator.SetFloat(movementHash, 0);
            }
            else
            {
                animator.SetFloat(movementHash, 1);
            }*/
        }

    
    }


}
