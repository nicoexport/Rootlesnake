using UnityEngine;

namespace Rootlesnake {
    public class NutrientSpawner : MonoBehaviour {
        [SerializeField] int numberOfNutrients = 100;
        [SerializeField] Color color = Color.green;

        [ContextMenu("NUTRIENTS!")]
        protected void Start() {
            for (int i = 0; i < numberOfNutrients; i++) {
                int randX = Random.Range(0, TextureManager.instance.playSpaceSize.x);
                int randY = Random.Range(0, TextureManager.instance.playSpaceSize.y);
                var target = new Vector2(randX, randY);
                TextureManager.instance.DrawPixelWorldSpace(color, target);
            }
        }
    }
}