using UnityEngine;

public class EmojiSelecter : MyMonoBehavior
{
    private static EmojiSelecter instance;
    public static EmojiSelecter Instance => instance;

    private string emojiSelected = "";
    public string EmojiSelected => emojiSelected;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
    protected virtual void Update() 
    {
        emojiSelected = PlayerPrefs.GetString("SelectEmoji");
    }

    public virtual void LoadEmoji(string nameEmoji)
    {
        PlayerPrefs.SetString("SelectEmoji", nameEmoji);
    }
}
