using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CharacterEvent : MyMonoBehavior
{
    [SerializeField] protected FrogToxic frog;
    public FrogToxic Frog => frog;
    [SerializeField] protected HumanEventChecker human;
    public HumanEventChecker Human => human;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCharacterToxicFrog();
        LoadHuman();
    }

    protected virtual void LoadCharacterToxicFrog()
    {
        if (frog != null) return;
        frog = transform.GetComponentInChildren<FrogToxic>();
    }

    protected virtual void LoadHuman()
    {
        if(human != null) return;
        human = transform.GetComponentInChildren<HumanEventChecker>();
    }


}
