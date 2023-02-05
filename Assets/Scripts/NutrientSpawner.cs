using UnityEngine;

namespace Rootlesnake {
    public class NutrientSpawner : MonoBehaviour {
        [SerializeField]
        int numberOfNutrients = 100;

        [ContextMenu("NUTRIENTS!")]
        protected void Start() {
            for (int i = 0; i < numberOfNutrients; i++) {
                int randX = Random.Range(0, TextureManager.instance.renderSize.x);
                int randY = Random.Range(0, TextureManager.instance.renderSize.y);

                TextureManager.instance.DrawDotPixelSpace(
                    GameManager.instance.collisionColors.nutrient,
                    new(randX, randY)
                );
            }
        }
    }
}