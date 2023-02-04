using UnityEngine;

namespace Rootlesnake {
    public class NutrientSpawner : MonoBehaviour {
        [SerializeField] private int numberOfNutrients;
        private int x;
        private int y;

        protected void Start() {
            for (int i = 0; i < numberOfNutrients; i++) {
                var randX = Random.Range(0, x);
                var randY = Random.Range(0, y);
            }
        }
    }
}