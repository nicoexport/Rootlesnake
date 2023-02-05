using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rootlesnake.Effects {
    [CreateAssetMenu]
    sealed class InvokeGameManager : ScriptableEffect {
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
        protected override void InvokeNow(GameObject context) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
