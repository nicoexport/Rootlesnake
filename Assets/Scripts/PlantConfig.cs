using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Rootlesnake {
    [CreateAssetMenu]
    sealed class PlantConfig : ScriptableObject {
        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public Sprite sprite;
    }
}
