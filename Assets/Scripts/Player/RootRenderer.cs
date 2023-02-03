using System.Linq;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootRenderer : MonoBehaviour {
        [SerializeField]
        RootController controller;
        Root root => controller.root;
        [SerializeField]
        LineRenderer line;

        void OnValidate() {
            if (!controller) {
                transform.TryGetComponentInParent(out controller);
            }
            if (!line) {
                transform.TryGetComponentInParent(out line);
            }
        }
        void OnEnable() {
            root.onUpdatePoints += UpdateLine;
        }
        void OnDisable() {
            root.onUpdatePoints += UpdateLine;
        }
        void Start() {
            UpdateLine();
        }

        void UpdateLine() {
            line.positionCount = root.points.Count;
            line.SetPositions(root.points.ToArray());
        }
    }
}
