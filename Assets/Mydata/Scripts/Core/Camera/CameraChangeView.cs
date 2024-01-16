//using System;
//using UnityEngine;

//namespace Rainbow {
//    public class CameraChangeView : MonoBehaviour {
//        private CameraController cam;

//        private void Start() {
//            cam = FindObjectOfType<CameraController>();
//        }

//        public bool isViewTPS { 
//            get {
//                if (cam == null) return false;
//                if (cam.GetCinemachineCamera(CameraProfileEnum.CHARACTER_FOCUS_TPS).enabled) return true;
//                else return false;
//            }
//        }
//        public void ChangeView() {
//            if (isViewTPS) {
//                ChangeToViewTopDown();
//            }
//            else {
//                ChangeToViewTPS();
//            }
//        }

//        private void ChangeToViewTPS() {
//            if (cam) {
//                var current = cam.GetCinemachineCamera(CameraProfileEnum.CHARACTER_FOCUS_TOPDOWN);
//                cam.ActiveCameraProfile(CameraProfileEnum.CHARACTER_FOCUS_TPS, current?.Follow);
//            }
//        }

//        private void ChangeToViewTopDown() {
//            if (cam) {
//                var current = cam.GetCinemachineCamera(CameraProfileEnum.CHARACTER_FOCUS_TPS);
//                cam.ActiveCameraProfile(CameraProfileEnum.CHARACTER_FOCUS_TOPDOWN, current?.Follow);
//            }

//        }
//    }
//}
