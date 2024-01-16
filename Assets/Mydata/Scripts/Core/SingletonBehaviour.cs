using UnityEngine;
namespace CoreGame {
    public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour {
        private static T _instance;

        public static T Instance {
            get {
                if (_instance != null) return _instance;
                _instance = (new GameObject(typeof(T).Name)).AddComponent<T>();
                return _instance;
            }
        }

        public static bool Initialized => _instance != null;

        protected virtual bool DontDestroy => false;

        protected virtual void OnAwake() { }

        private void Awake() {
            if (_instance == null) {
                _instance = this as T;
            }
            else if (_instance != this as T) {
                Destroy(gameObject);
                return;
            }

            if (DontDestroy) DontDestroyOnLoad(gameObject);

            OnAwake();
        }

        public virtual void Preload() { }
    }

    public class SingletonBehaviourDontDestroy<T> : SingletonBehaviour<T> where T : MonoBehaviour {
        protected override bool DontDestroy => true;
    }
}

