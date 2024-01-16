using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogToxic : MyMonoBehavior
{
    [SerializeField] private CharacterEvent character;
    [SerializeField] private Transform boomEffect;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCharacterHuman();
    }

    protected virtual void LoadCharacterHuman()
    {
        if (character != null) return;
        character = transform.parent.GetComponent<CharacterEvent>();
    }

    protected override void Start()
    {
        base.Start();
        character.Human.transform.parent.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ArrowActiveEvent"))
        {
            transform.gameObject.SetActive(false);
            character.Human.transform.parent.gameObject.SetActive(true);
            boomEffect.gameObject.SetActive(true);
            ArrowSpawner.Instance.Despawn(other.gameObject.transform);
        }
    }

}
