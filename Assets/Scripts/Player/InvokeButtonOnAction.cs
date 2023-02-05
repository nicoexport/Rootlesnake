using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Rootlesnake.Player {
    sealed class InvokeButtonOnAction : MonoBehaviour {
        [SerializeField]
        Button button;
        [SerializeField]
        InputActionReference input = default;

        void OnValidate() {
            if (!button) {
                TryGetComponent(out button);
            }
        }

        void OnEnable() {
            input.asset.Enable();
            input.action.performed += OnInput;
        }
        void OnDisable() {
            input.action.performed -= OnInput;
        }

        void OnInput(InputAction.CallbackContext obj) {
            button.onClick.Invoke();
        }
    }
}
