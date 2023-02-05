using System.Collections.Generic;
using UnityEngine;

namespace Rootlesnake {
    [CreateAssetMenu]
    sealed class ColorSettings : ScriptableObject {
        [SerializeField]
        [ColorUsage(true, true)]
        public Color playerOne = new(0, 0, 0, 1);
        [SerializeField]
        [ColorUsage(true, true)]
        public Color playerTwo = new(0, 0, 1, 1);
        [SerializeField]
        [ColorUsage(true, true)]
        public Color playerThree = new(0, 1, 0, 1);
        [SerializeField]
        [ColorUsage(true, true)]
        public Color playerFour = new(0, 1, 1, 1);

        [Space]
        [SerializeField]
        [ColorUsage(true, true)]
        public Color deadPlayerOne = new(1, 0, 0, 1);
        [SerializeField]
        [ColorUsage(true, true)]
        public Color deadPlayerTwo = new(1, 0, 1, 1);
        [SerializeField]
        [ColorUsage(true, true)]
        public Color deadPlayerThree = new(1, 1, 0, 1);
        [SerializeField]
        [ColorUsage(true, true)]
        public Color deadPlayerFour = new(1, 1, 1, 1);

        [Space]
        [SerializeField]
        [ColorUsage(true, true)]
        public Color nutrient = new(0.5f, 0.5f, 0.5f, 1);

        public IEnumerable<Color> colors {
            get {
                yield return playerOne;
                yield return playerTwo;
                yield return playerThree;
                yield return playerFour;
                yield return deadPlayerOne;
                yield return deadPlayerTwo;
                yield return deadPlayerThree;
                yield return deadPlayerFour;
                yield return nutrient;
            }
        }
    }
}
