using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointSpawnEffect : MyMonoBehavior
{
    public virtual void SpawnEffects(TypeEmojiArrow typeEmoji)
    {
        switch (typeEmoji)
        {
            case TypeEmojiArrow.Eat:
                StartSpawn("Eat");
                break;
            case TypeEmojiArrow.Excercise:
                StartSpawn("Excercise");
                break;
            case TypeEmojiArrow.Sing:
                StartSpawn("Sing");
                break;
            case TypeEmojiArrow.Cry:
                StartSpawn("Cry");
                break;
            case TypeEmojiArrow.Happy:
                StartSpawn("Happy");
                break;
            case TypeEmojiArrow.Vote:
                StartSpawn("Vote");
                break;
            case TypeEmojiArrow.Angry:
                StartSpawn("Angry");
                break;
            default:
                StartDespawnEffect();
                break;

        }
    }

    protected virtual void StartSpawn(string nameEffect)
    {
        //For override
    }

    protected virtual void StartDespawnEffect() 
    {
        //For override
    }

}
