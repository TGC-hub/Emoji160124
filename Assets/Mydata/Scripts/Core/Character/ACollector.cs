using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACollector<T> : AInteractable where T : MonoBehaviour
{
     protected virtual void OnTriggerEnter(Collider other) {
        if(other == null) return;
        var target = other.GetComponent<IInteractable>();
        if(target != null) {
            target.OnInteract(this);
            if(target is T) {
                OnInteract(target as T);
            }
        }
    }

    protected virtual void OnInteract(T target) { }
}
