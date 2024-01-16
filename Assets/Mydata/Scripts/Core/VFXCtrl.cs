using CoreGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeVFX {
    None,
    Combat
}

public class VFXCtrl : SingletonBehaviour<VFXCtrl> {
    [SerializeField] private ParticleSystem combatVfx;

    private List<ParticleSystem> poolCombatVFX;

    public int amountToPool;


    void Start() {
        //SpawnObjectPool(ref poolCombatVFX, combatVfx, amountToPool);
    }

    /// <summary>
    /// Prepare object
    /// </summary>
    /// <param name="list"></param>
    /// <param name="pref"></param>
    /// <param name="amount"></param>

    private void SpawnObjectPool(ref List<ParticleSystem> list, ParticleSystem pref, int amount) {
        list = new List<ParticleSystem>();
        ParticleSystem tmp;
        for (int i = 0; i < amountToPool; i++) {
            tmp = Instantiate(pref, transform);
            tmp.gameObject.SetActive(false);
            list.Add(tmp);
        }
    }

    private ParticleSystem GetPooledObject(List<ParticleSystem> pooledObjects) {
        for (int i = 0; i < pooledObjects.Count; i++) {
            if (!pooledObjects[i].gameObject.activeInHierarchy) {
                return pooledObjects[i];
            }
        }
        return null;
    }

     #region Show VFX

    /// <summary>
    /// Show vfx and destroy
    /// </summary>
    /// <param name="vfxPrefabs"></param>
    /// <param name="parent"></param>
    public static void ShowVFX(ParticleSystem vfxPrefabs, Transform parent) {
        var vfxClone = Instantiate(vfxPrefabs);
        vfxClone.transform.position = parent.position;
        vfxClone.transform.SetParent(parent);
        vfxClone.gameObject.SetActive(true);
        vfxClone.Play();
        Destroy(vfxClone.gameObject, 1.25f);
    }
    public static void ShowVFX(ParticleSystem vfxPrefabs, Vector3 position, float timeDestroy = 1.25f) {
        var vfxClone = Instantiate(vfxPrefabs);
        vfxClone.transform.position = position;
        vfxClone.transform.SetParent(null);
        vfxClone.gameObject.SetActive(true);
        vfxClone.Play();
        Destroy(vfxClone.gameObject, timeDestroy);
    }
    IEnumerator waitOneSecond(GameObject targetDisable, float timeDelay = 1.25f) {
        yield return new WaitForSeconds(timeDelay);
        targetDisable.SetActive(false);
    }


    public void ShowVFX(TypeVFX type, Vector3 position) {
        //List<ParticleSystem> listVFX;
        ParticleSystem vfxClone;
        switch (type) {
            case TypeVFX.Combat: {
                    //listVFX = poolCombatVFX;
                    vfxClone = combatVfx;
                    break;
                }
            default: {
                    Debug.Log("Out of Type");
                    return;
                }
        }
        //var vfxClone = GetPooledObject(listVFX);
        if (vfxClone == null) return;
        vfxClone.transform.position = position;
        vfxClone.gameObject.SetActive(true);
        vfxClone.Play();
        StartCoroutine(waitOneSecond(vfxClone.gameObject));
    }
    #endregion

}