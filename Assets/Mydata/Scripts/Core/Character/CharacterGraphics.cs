using CoreGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGraphics : MonoBehaviour {


    private void LoadNewModel(string typeEmoji) {
        TypeEmojiArrow type = TypeEmojiArrow.None;
        switch (typeEmoji) {
            case "Eat": {
                    type = TypeEmojiArrow.Eat;
                    break;
                }
            case "Excercise": {
                    type = TypeEmojiArrow.Excercise;
                    break;
                }
            default: {
                    return;
            }
        }
        EventTrigger.Trigger<TypeEmojiArrow>(EventDefine.LoadNewModel, type);
    }

    #region Old
    //[SerializeField] private SkinnedMeshRenderer[] normalskins;
    //[SerializeField] private Mesh[] normalMesh;
    //[SerializeField] private Mesh[] fatMesh;
    //[SerializeField] private Mesh[] thinMesh;
    //// Start is called before the first frame update

    //private void LoadNewModel(string typeEmoji) {
    //    switch (typeEmoji) {
    //        case "Eat": {
    //                //LoadNewModel
    //                LoadMesh(normalskins, fatMesh);
    //                break;
    //            }
    //        case "Excercise": {
    //                LoadMesh(normalskins, thinMesh);
    //                //LoadNewModel
    //                break;
    //            }
    //        default: {
    //                LoadMesh(normalskins, normalMesh);
    //                break;
    //            }
    //    }
    //}

    //private void LoadMesh(SkinnedMeshRenderer[] skins, Mesh[] meshs) {
    //    if (skins == null || meshs == null || skins.Length <= 0 || meshs.Length <= 0) return;
    //    int length = Mathf.Min(skins.Length, meshs.Length);
    //    for (int i = 0; i < length; i++) {
    //        if (skins[i] != null && meshs[i] != null) {
    //            skins[i].sharedMesh = meshs[i];
    //        }
    //    }
    //}
    #endregion
}
