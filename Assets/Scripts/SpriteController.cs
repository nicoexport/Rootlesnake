using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake {
    sealed class SpriteController : MonoBehaviour {
        [SerializeField]
        SpriteRenderer sprite;

        void OnValidate() {
            if (!sprite) {
                transform.TryGetComponentInParent(out sprite);
            }
        }

        void Start() {
            sprite.material.mainTexture = TextureManager.instance.collisionTexture;
        }
    }
}
