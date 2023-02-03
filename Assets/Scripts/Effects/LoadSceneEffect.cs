using MyBox;
using Rootlesnake.Effects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rootlesnake {
    [CreateAssetMenu(menuName = "Effects/" + nameof(LoadSceneEffect))]
    sealed class LoadSceneEffect : ScriptableEffect {
        [SerializeField]
        SceneReference scene = new();
        [SerializeField]
        LoadSceneMode loadSceneMode = LoadSceneMode.Single;

        protected override void InvokeNow(GameObject context) {
            scene.LoadSceneAsync(loadSceneMode);
        }
    }
}
