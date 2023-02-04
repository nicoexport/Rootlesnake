using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootLineRenderer : MonoBehaviour {
        [SerializeField]
        RootController controller;
        IPlant root => controller.root;

        [Space]
        [SerializeField, Expandable]
        LineRenderer linePrefab;

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
            var lineInstance = Instantiate(linePrefab, transform);
            branch.onUpdateNodeCount += () => {
                lineInstance.positionCount = branch.nodeCount;
                lineInstance.SetPositions(branch.nodes.Select(node => node.position).ToArray());
            };
            branch.onUpdateNodePositions += () => {
                lineInstance.SetPosition(0, branch.head.position);
            };
        }
    }
}
