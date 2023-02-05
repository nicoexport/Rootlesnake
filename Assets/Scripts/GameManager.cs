using System;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    sealed class GameManager : MonoBehaviour {
        [SerializeField, Expandable]
        ColorSettings m_playfieldColors;
        public ColorSettings playfieldColors => m_playfieldColors;
        [SerializeField, Expandable]
        ColorSettings m_collisionColors;
        public ColorSettings collisionColors => m_collisionColors;

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

        public bool IsNutrient(in Color color) {
            if (color != Color.black) {
                Debug.Log(m_collisionColors.nutrient + " :: " + color);
            }
            return m_collisionColors.nutrient == color;
        }
    }
}
