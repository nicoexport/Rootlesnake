using UnityEngine;

namespace Rootlesnake {
    public class NutrientSpawner : MonoBehaviour {
        [SerializeField] int numberOfNutrients = 100;
        [SerializeField] private ColorSettings colorSettings;

        [ContextMenu("NUTRIENTS!")]
        protected void Start() {
            for (int i = 0; i < numberOfNutrients; i++) {
                int randX = Random.Range(-TextureManager.instance.playSpaceSize.x / 2, TextureManager.instance.playSpaceSize.x / 2);
                int randY = Random.Range(-TextureManager.instance.playSpaceSize.y / 2, TextureManager.instance.playSpaceSize.y / 2);
                var target = new Vector2(randX, randY);
                TextureManager.instance.DrawPixelWorldSpace(new Color(0.5f, 0.5f, 0.5f, 1f), target);
            }
        }
    }
}   