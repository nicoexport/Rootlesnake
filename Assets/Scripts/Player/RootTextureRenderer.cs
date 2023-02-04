using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootTextureRenderer : MonoBehaviour {
        [SerializeField]
        RootController controller;
        IPlant root => controller.root;

        void OnValidate() {
            if (!controller) {
                transform.TryGetComponentInParent(out controller);
            }
        }
        void OnEnable() {
            root.onAddBranch += AddBranch;
        }
        void OnDisable() {
            root.onAddBranch -= AddBranch;
        }

        void AddBranch(IPlantBranch branch) {
            branch.onUpdateHeadPosition += (start, stop) => {
                TextureManager.instance.DrawLineWorldSpace(root.playerColor, start, stop);
            };
        }
    }
}
