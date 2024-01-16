using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Evaluation", menuName = "ScriptableObjects/Evaluation")]
public class Evaluation : ScriptableObject
{
    public float current = 50f;
    public float currentLevel;
    public float level = 1f;

    public float SetCurrentLevel(float current)
    {
        level++;
        return current/level;
    }
}
