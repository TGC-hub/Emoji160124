using UnityEngine;

public class Levelnfo : MonoBehaviour
{
    [SerializeField] private int totalPhase;
    [SerializeField] private LevelPhase[] levelPhases;
    [SerializeField] private Character mainCharacter;

    public int TotalPhase => totalPhase;

    public Character MainChar => mainCharacter;

    public LevelPhase GetCurPhase(int phase)
    {
        if (phase < 0 || phase >= totalPhase) return null;
        else return levelPhases[phase];
    }
    public void CheckActivePhase(int phase)
    {
        if (phase < 0 || phase >= totalPhase) return;
        for(int i = 0; i< levelPhases.Length; i++) {
            levelPhases[i].gameObject.SetActive(i == phase);
        }
    }

}
