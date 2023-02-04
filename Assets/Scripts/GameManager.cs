using System;
using UnityEngine;

namespace Rootlesnake {
    sealed class GameManager : MonoBehaviour {
        public static GameManager instance { get; private set; }

        public static event Action onPreMoveRoots;
        public static event Action<float> onMoveRoots;
        public static event Action onPostMoveRoots;

        void Awake() {
            instance = this;
        }

        void FixedUpdate() {
            onPreMoveRoots?.Invoke();
            onMoveRoots?.Invoke(Time.deltaTime);
            onPostMoveRoots?.Invoke();
        }
    }
}
