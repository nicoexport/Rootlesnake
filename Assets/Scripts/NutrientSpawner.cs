using UnityEngine;

namespace Rootlesnake {
    public class NutrientSpawner : MonoBehaviour {
        [SerializeField]
        int numberOfNutrients = 100;

        [ContextMenu("NUTRIENTS!")]
        protected void Start() {
            for (int i = 0; i < numberOfNutrients; i++) {
                int randX = Random.Range(-TextureManager.instance.playfieldSize.x / 2, TextureManager.instance.playfieldSize.x / 2);
                int randY = Random.Range(-TextureManager.instance.playfieldSize.y / 2, TextureManager.instance.playfieldSize.y / 2);
                var target = new Vector2(randX, randY);
                TextureManager.instance.DrawPixelWorldSpace(
                    GameManager.instance.collisionColors.nutrient,
                    target
                );
            }
        }
    }
}