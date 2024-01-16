using CoreGame;
using System.Threading.Tasks;
using UnityEngine;

public class LevelSpawner : SingletonBehaviour<LevelSpawner>
{
    [SerializeField] private Levelnfo[] levelInfo;
    [SerializeField] private int mLevel = 0;
    public Levelnfo CurrentLevel { get; private set; } 

    public void LoadLevel(int level)
    {
        level--;
        // CurrentLevel = levelInfo[level % 2];
        CurrentLevel = levelInfo[0];
        CurrentLevel.gameObject.SetActive(true);
    }

}
