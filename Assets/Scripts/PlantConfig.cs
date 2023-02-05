using Rootlesnake.Effects;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    [CreateAssetMenu]
    sealed class PlantConfig : ScriptableEffect {
        [SerializeField, Expandable]
        public GameObject prefab;
        [SerializeField, Expandable]
        public Sprite sprite;

        protected override void InvokeNow(GameObject context) => throw new System.NotImplementedException();
    }
}
