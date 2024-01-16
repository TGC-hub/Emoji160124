using UnityEngine;
using UnityEngine.Accessibility;

public class ArrowDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        ArrowSpawner.Instance.Despawn(transform.parent);
    }
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (CameraController.Instance.currentCamera == CameraController.Instance.VirtualCameraPlayer) return;
        ArrowSpawner.Instance.Despawn(transform.parent);
    }

}
