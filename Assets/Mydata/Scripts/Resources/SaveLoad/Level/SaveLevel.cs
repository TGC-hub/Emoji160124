using UnityEngine;
[CreateAssetMenu(fileName = "SaveLoad", menuName = "ScriptableObjects/SaveLevel")]
public class SaveLevel : ScriptableObject
{
    public int level = 1;

    public int SetLevel(int setlevel)
    {
        return level = setlevel;
    }
}
