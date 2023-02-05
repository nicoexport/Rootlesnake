using System;
using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    sealed class GameManager : MonoBehaviour {
        public static GameManager instance { get; private set; }

        public static event Action onStartRound;

        [SerializeField, Expandable]
        ColorSettings m_playfieldColors;
        public ColorSettings playfieldColors => m_playfieldColors;
        [SerializeField, Expandable]
        ColorSettings m_collisionColors;
        public ColorSettings collisionColors => m_collisionColors;

        [SerializeField]
        public PlantConfig[] plants = Array.Empty<PlantConfig>();

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

        public Color CollisionColorToPlayfieldColor(in Color color) {
            int i = 0;
            foreach (var testColor in collisionColors.colors) {
                if (IsApproximately(testColor, color)) {
                    break;
                }
                i++;
            }
            return playfieldColors.colors.ElementAt(i);
        }
        public bool IsBackground(in Color color) {
            return IsApproximately(m_collisionColors.background, color);
        }
        public bool IsNutrient(in Color color) {
            return IsApproximately(m_collisionColors.nutrient, color);
        }
        static bool IsApproximately(in Color a, in Color b, float delta = 0.25f) {
            return Math.Abs(a.r - b.r) < delta
                && Math.Abs(a.g - b.g) < delta
                && Math.Abs(a.b - b.b) < delta
                && Math.Abs(a.a - b.a) < delta;
        }

        public void StartRound() {
            onStartRound?.Invoke();
            AudioManager.instance.PlayAudio(Audio.BGM);
        }
    }
}
