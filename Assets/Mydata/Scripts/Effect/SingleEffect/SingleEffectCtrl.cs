using UnityEngine;
public class SingleEffectCtrl : PointSpawnEffect
{
    [SerializeField] protected Transform obj;

    protected virtual void SpawnSingleEffect(string nameTransform)
    {
        DespawnEffect();
        Vector3 pos = transform.position;
        Quaternion rot = transform.localRotation;
        obj = SingleEffectSpawner.Instance.Spawn(nameTransform, pos, rot);
        obj.gameObject.SetActive(true);
        obj.SetParent(transform);
    }
    public virtual void DespawnEffect()
    {
        if (obj == null) return;
        SingleEffectSpawner.Instance.Despawn(this.obj);
    }

    protected override void StartSpawn(string nameEffect)
    {
        base.StartSpawn(nameEffect);
        SpawnSingleEffect(nameEffect);
    }

    protected override void StartDespawnEffect()
    {
        base.StartDespawnEffect();
        DespawnEffect();
    }
}
