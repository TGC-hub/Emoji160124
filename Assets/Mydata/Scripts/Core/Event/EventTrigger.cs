using System;
using UnityEngine;
namespace CoreGame {
    public class EventTrigger : MonoBehaviour {
        public static void Trigger(Action action) {
            action?.Invoke();
        }
        public static void Trigger<T>(Action<T> action, T param) {
            action?.Invoke(param);
        }
        public static void Trigger<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2) {
            action?.Invoke(param1, param2);
        }

        public static void Trigger<T1, T2, T3>(Action<T1, T2, T3> action, T1 param1, T2 param2, T3 param3) {
            action?.Invoke(param1, param2, param3);
        }
        public static void Trigger<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 param1, T2 param2, T3 param3, T4 param4) {
            action?.Invoke(param1, param2, param3, param4);
        }
        public static bool CheckActionInEvent(Delegate action, Delegate listener) {
            if (action != null) {
                foreach (var existingListener in action.GetInvocationList()) {
                    if (existingListener == listener) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
