
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform playerPos;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMainCamera();
    }

    protected virtual void LoadMainCamera()
    {
        if (playerPos != null) return;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(this.transform.position,playerPos.position);
        if (distance > disLimit) { return true; }
        else
        {
            return false;
        }
    }
}
