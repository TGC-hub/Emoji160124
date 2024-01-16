using CoreGame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EmojiController : MyMonoBehavior
{
    [SerializeField] protected List<Transform> emoji;
    [SerializeField] protected List<TypeEmojiArrow> listEmojiMission;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.emoji.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.emoji.Add(prefab);
            }
            this.HidePrefabs();
        }

    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.emoji)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    protected override void Awake()
    {
        EventDefine.NextPhase += ReloadEmojiButton;
    }

    private void OnDestroy()
    {
        EventDefine.NextPhase -= ReloadEmojiButton;
    }

    protected virtual void FixedUpdate()
    {
/*        list = MissionManager.Instance.ListEmoji;
        foreach (Transform transformA in emoji)
        {
            bool containsTransform = list.Any(item => item.GetComponent<Image>().sprite == transformA.GetComponent<Image>().sprite);

            if (containsTransform)
            {
                transformA.gameObject.SetActive(true);
            }
            else
            {
                transformA.gameObject.SetActive(false);
            }
        }*/
    }

    public void ReloadEmojiButton()
    {
        var allEmoji =  GameController.Instance.GetAllEmoji();
        foreach (Transform obj in emoji)
        {
            if(Array.Exists(allEmoji, value => (value != TypeEmojiArrow.Unvote) && ("Emoji" + value.ToString() == obj.name)))
            {
                obj.gameObject.SetActive(true);
            }
            else
            {
                obj.gameObject.SetActive(false);
            }

        }

        listEmojiMission.Clear();

        foreach (TypeEmojiArrow emojiArrow in allEmoji)
        {
            listEmojiMission.Add(emojiArrow);
        }

        EmojiSelecter.Instance.LoadEmoji("Emoji" + RandomListEmoji());
    }

    public virtual string RandomListEmoji()
    {
        int rand = UnityEngine.Random.Range(0, this.listEmojiMission.Count);
        return this.listEmojiMission[rand].ToString();
    }

}
