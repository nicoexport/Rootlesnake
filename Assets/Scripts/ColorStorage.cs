using System;
using UnityEngine;

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
