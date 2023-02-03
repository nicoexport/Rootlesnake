using Rootlesnake.Effects;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rootlesnake.Player {
    sealed class CallEffectOnButton : MonoBehaviour {
        [SerializeField, Expandable]
        ScriptableEffect effect;

        [SerializeField]
        InputActionReference input = default;

        void OnEnable() {
            input.asset.Enable();
            input.action.performed += OnInput;
        }
        void OnDisable() {
            input.action.performed -= OnInput;
        }

        void OnInput(InputAction.CallbackContext obj) {
            effect.Invoke(gameObject);
        }
    }
}
