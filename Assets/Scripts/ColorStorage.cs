using System;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Rootlesnake {
    [CreateAssetMenu]
    sealed class ColorStorage : ScriptableObject {
        
        public PickableColors[] colors;

        [Serializable]
        public struct PickableColors {
            
            [ColorUsage(true, true)]
            public Color color;
            public bool isPicked;
        }
    }
}
