using Rootlesnake.Input;
using Slothsoft.UnityExtensions;
using UnityEngine;

namespace Rootlesnake.Player {
    sealed class HumanIntentions : MonoBehaviour {
        [SerializeField]
        RootController controller;
        Root root => controller.root;

        Controls controls;

        void OnValidate() {
            if (!controller) {
                transform.TryGetComponentInParent(out controller);
            }
        }
        void Awake() {
            controls = new();
        }
        void OnEnable() {
            controls.Enable();
        }
        void OnDisable() {
            controls.Disable();
        }
        void Update() {
            if (controls.Root.Move.IsInProgress()) {
                root.intendedDirection = controls.Root.Move.ReadValue<Vector2>();
            }
        }
    }
}
