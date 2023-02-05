using UnityEngine;

namespace Rootlesnake.Effects {
    [CreateAssetMenu]
    sealed class InvokeAudioManager : ScriptableEffect {
        [SerializeField]
        Audio cue;
        protected override void InvokeNow(GameObject context) {
            AudioManager.instance.PlayAudio(cue);
        }
    }
}
