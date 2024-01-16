using UnityEngine;

public class DoubleEffectCtrl : PointSpawnEffect
{
    [SerializeField] protected Transform obj;
    [SerializeField] protected Vector3 offset = Vector3.forward;
    [SerializeField] protected Vector3 posTarget;

    protected virtual void SpawnDoubleEffect(string nameTransform)
    {
        DespawnEffect();
        Vector3 pos = posTarget + (transform.parent.forward)/2;
        Quaternion rot = transform.localRotation;
        
        obj = DoubleEffectSpawner.Instance.Spawn(nameTransform, pos, rot);
        obj.gameObject.SetActive(true);
    }
    public virtual void DespawnEffect()
    {
        if (obj == null) return;
        obj.position = Vector3.zero;
        DoubleEffectSpawner.Instance.Despawn(this.obj);
    }

    protected override void StartSpawn(string nameEffect)
    {
        base.StartSpawn(nameEffect);
        SpawnDoubleEffect(nameEffect);
    }

    protected override void StartDespawnEffect()
    {
        base.StartDespawnEffect();
        DespawnEffect();
    }

    public virtual Vector3 GetPosTarget(Vector3 vector3)
    {
        return posTarget = vector3;
    }
}
