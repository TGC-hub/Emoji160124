using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
namespace CoreGame {

    public enum CameraProfileEnum {
        MainCam,
        OverviewCam,
        FirstLookCam,
        SecondLookCam,
    }

    public class CameraController : SingletonBehaviour<CameraController> {
        [System.Serializable]
        public struct CameraProfile  {
            [field: SerializeField]
            public Transform Target { get; set; }
            public CameraProfileEnum cameraProfileEnum;
            public Cinemachine.CinemachineVirtualCameraBase cinemachineCamera;
            public bool setFollow;
            public bool setLookAt;
        }

        [SerializeField] private CameraProfile[] profiles;

        private Dictionary<int, CameraProfile> camProfileMapping;

        public CinemachineVirtualCamera CurrentCam { get; private set; }

        protected void Awake() {
            camProfileMapping = new Dictionary<int, CameraProfile>();

            foreach (var c in profiles) {
                camProfileMapping[(int)c.cameraProfileEnum] = c;
            }
        }
        
        public void ActiveCameraProfile(CameraProfileEnum profileEnum, Transform target = null, bool lerpCamPosition = true) {
            //here : need to check if the profile is active or not
            Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseInOut, lerpCamPosition ? 1f : 0f);
            int id = (int)profileEnum;

            //only active if the profile is available
            if (camProfileMapping.TryGetValue(id, out var p)) {
                foreach (var kv in camProfileMapping) {
                    bool enable = id == kv.Key;
                    var profile = kv.Value;

                    if (enable ^ profile.cinemachineCamera.enabled) {
                        profile.cinemachineCamera.enabled = enable;
                    }
                }

                CurrentCam = p.cinemachineCamera as CinemachineVirtualCamera;

                if (target != null) {
                    if (p.setFollow)
                        p.cinemachineCamera.Follow = target;
                    if (p.setLookAt) {
                        p.cinemachineCamera.LookAt = target;
                    }

                }
            }
        }

        public float ActiveCameraProfile(CinemachineVirtualCamera customCineCamera, bool lerpCamPosition = true) {
            foreach (var kv in camProfileMapping) kv.Value.cinemachineCamera.enabled = false;
            customCineCamera.gameObject.SetActive(true);
            CurrentCam = customCineCamera;
            if (!lerpCamPosition) {
                var cam = Camera.main.GetComponent<CinemachineBrain>();
                var value = cam.m_DefaultBlend;
                cam.m_DefaultBlend = new CinemachineBlendDefinition(CinemachineBlendDefinition.Style.EaseInOut, 0f);
                CurrentCam.transform.position = customCineCamera.transform.position;
            }
            return customCineCamera.GetComponent<Animation>().clip.length;
        }


        public Cinemachine.CinemachineVirtualCameraBase GetCinemachineCamera(CameraProfileEnum profileEnum) {
            int id = (int)profileEnum;
            if (camProfileMapping.TryGetValue(id, out var p)) {
                return p.cinemachineCamera;
            }
            return null;
        }

    }

}
