
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission", menuName = "ScriptableObjects/Mission")]
public class Mission : ScriptableObject
{
    public Transform emoji;

    public Transform targetLeft;

    public Transform targetRight;

    public int numberTarget;

    public string nameMission;

    public List<Transform> listEmoji;
}
