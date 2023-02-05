using UnityEngine;

namespace Rootlesnake {
    [CreateAssetMenu]
    sealed class PlantConfig : ScriptableObject {
        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public Sprite sprite;
    }
}
