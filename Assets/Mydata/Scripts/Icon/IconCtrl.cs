using UnityEngine;

public class IconCtrl : PointSpawnEffect
{
    [SerializeField] protected Transform obj;
    protected virtual void SpawnIcon(string nameTransform)
    {
        DespawnIconEmoji();
        Vector3 pos = transform.position;
        Quaternion rot = transform.localRotation;
        obj = IconSpawner.Instance.Spawn(nameTransform, pos, rot);
        obj.gameObject.SetActive(true);
        obj.SetParent(transform);
    }
    public virtual void DespawnIconEmoji()
    {
        if (obj == null) return;
        IconSpawner.Instance.Despawn(this.obj);
    }

    protected override void StartSpawn(string nameEffect)
    {
        base.StartSpawn(nameEffect);
        SpawnIcon(nameEffect);
    }

    protected override void StartDespawnEffect()
    {
        base.StartDespawnEffect();
        DespawnIconEmoji();
    }
}
