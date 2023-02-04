using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rootlesnake.Player {
    sealed class HumanIntentions : MonoBehaviour {
        [SerializeField]
        PlayerInput input;
        [SerializeField]
        RootController controllerPrefab;

        [Space]
        [SerializeField, ReadOnly]
        RootController controllerInstance;
        IPlant root => controllerInstance.root;
        void OnValidate() {
            if (!input) {
                transform.TryGetComponentInParent(out input);
            }
        }
        void OnEnable() {
            controllerInstance = Instantiate(controllerPrefab, transform);
            controllerInstance.SetPlayerIndex(input.playerIndex);

            input.actions["Move"].performed += PerformMove;
            input.actions["Interact"].performed += PerformInteraction;
        }
        void OnDisable() {
            Destroy(controllerInstance);
            input.actions["Move"].performed -= PerformMove;
            input.actions["Interact"].performed -= PerformInteraction;
        }

        void PerformMove(InputAction.CallbackContext context) {
            root.SetIntendedDirection(context.ReadValue<Vector2>());
        }

        void PerformInteraction(InputAction.CallbackContext context) {
            root.IntendToSplit();
        }
    }
}
