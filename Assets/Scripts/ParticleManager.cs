using UnityEngine;

namespace Rootlesnake {
    sealed class ParticleManager : MonoBehaviour {

        public static ParticleManager instance { get; private set; }

        [SerializeField]
        GameObject plantGrowPrefab;
        [SerializeField]
        GameObject rootSplitPrefab;
        [SerializeField]
        GameObject nutrientCollectPrefab;

        void Awake() {
            instance = this;
        }

        public void PlayAudio(EffectCue cue, Transform context) {
            var prefab = cue switch {
                EffectCue.PlantGrow => plantGrowPrefab,
                EffectCue.RootSplit => rootSplitPrefab,
                EffectCue.NutrientCollect => nutrientCollectPrefab,
                _ => default,
            };
            if (prefab) {
                Instantiate(prefab, context);
            }
        }

        public void PlayAudio(EffectCue cue, Vector3 position) {
            var prefab = cue switch {
                EffectCue.RootSplit => rootSplitPrefab,
                EffectCue.NutrientCollect => nutrientCollectPrefab,
                _ => default,
            };
            if (prefab) {
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}