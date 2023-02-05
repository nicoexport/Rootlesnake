using UnityEngine;

namespace Rootlesnake.Effects {
    [CreateAssetMenu]
    sealed class InvokeAudioManager : ScriptableEffect {
        [SerializeField]
        EffectCue cue;
        protected override void InvokeNow(GameObject context) {
            AudioManager.instance.PlayAudio(cue);
        }
    }
}
