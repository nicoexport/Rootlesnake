using MyBox;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

namespace Rootlesnake.Player {
    sealed class HumanIntentions : MonoBehaviour {
        [SerializeField]
        PlayerInput input;
        [SerializeField]
        MultiplayerEventSystem eventSystem;
        [SerializeField]
        RootController controllerPrefab;
        [SerializeField, Expandable]
        public PlantConfig config;

        [Space]
        [SerializeField, ReadOnly]
        RootController controllerInstance;
        IPlant root => controllerInstance
            ? controllerInstance.root
            : null;
        void OnValidate() {
            if (!input) {
                transform.TryGetComponentInParent(out input);
            }
            if (!eventSystem) {
                transform.TryGetComponentInChildren(out eventSystem);
            }
        }
        void OnEnable() {
            input.actions["Move"].performed += PerformMove;
            input.actions["Interact"].performed += PerformInteraction;
        }
        void OnDisable() {
            Destroy(controllerInstance);
            input.actions["Move"].performed -= PerformMove;
            input.actions["Interact"].performed -= PerformInteraction;
        }

        void SpawnRoot() {
            controllerInstance = Instantiate(controllerPrefab, transform);
            controllerInstance.SetPlayerIndex(input.playerIndex);
        }

        void PerformMove(InputAction.CallbackContext context) {
            root?.SetIntendedDirection(context.ReadValue<Vector2>());
        }

        void PerformInteraction(InputAction.CallbackContext context) {
            root?.IntendToSplit();
        }
    }
}
