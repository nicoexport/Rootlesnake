using UnityEngine;

namespace Rootlesnake.Effects {
    [CreateAssetMenu]
    sealed class InvokeGameManager : ScriptableObject {
        public void Exit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
# else
            Application.Quit();
#endif
        }
        public void StartRound() {
            Debug.Log("Round Started");
        }
    }
}
