using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable {
    void OnInteract(IInteractable target);
    void EnableInteract();
    void DisableInteract();
}

public class AInteractable : MonoBehaviour, IInteractable {
    protected Vector3 halfSize;
    protected BoxCollider boxCollider;
    protected BoxCollider BoxCollider {
        get {
            if (boxCollider != null) return boxCollider;
            boxCollider = GetComponent<BoxCollider>();
            halfSize = boxCollider.size / 2f;
            return boxCollider;
        }
    }
    public virtual void SetColliderSize(Vector3 newSize) {
        BoxCollider.size = newSize;
        halfSize = boxCollider.size / 2f;
    }

    public bool IsInteractEnable => BoxCollider.enabled;

    public virtual void OnInteract(IInteractable other) {

    }

    public virtual void EnableInteract() {
        BoxCollider.enabled = true;
    }

    public virtual void DisableInteract() {
        BoxCollider.enabled = false;
    }

    protected virtual void RemoveSelf() {
        Destroy(gameObject);
    }

}
