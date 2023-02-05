using System.Collections.Generic;
using UnityEngine;

namespace Rootlesnake {
    [CreateAssetMenu]
    sealed class ColorSettings : ScriptableObject {
        [SerializeField]
        [ColorUsage(false, true)]
        public Color playerOne = new(0, 0, 0);
        [SerializeField]
        [ColorUsage(false, true)]
        public Color playerTwo = new(0, 0, 1);
        [SerializeField]
        [ColorUsage(false, true)]
        public Color playerThree = new(0, 1, 0);
        [SerializeField]
        [ColorUsage(false, true)]
        public Color playerFour = new(0, 1, 1);

        [Space]
        [SerializeField]
        [ColorUsage(false, true)]
        public Color deadPlayer = new(1, 0, 0);
        [SerializeField]
        [ColorUsage(false, true)]
        public Color nutrient = new(1, 1, 0);
        [SerializeField]
        [ColorUsage(false, true)]
        public Color background = new(1, 0, 1);

        public IEnumerable<Color> colors {
            get {
                yield return playerOne;
                yield return playerTwo;
                yield return playerThree;
                yield return playerFour;
                yield return deadPlayer;
                yield return nutrient;
                yield return background;
            }
        }
    }
}
