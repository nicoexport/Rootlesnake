using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rootlesnake.Player {
    sealed class PlayerManager : MonoBehaviour {
        public static PlayerManager instance { get; private set; }
        [SerializeField]
        PlayerInputManager manager;
        [SerializeField]
        Transform[] playerAnchors = Array.Empty<Transform>();

        void OnValidate() {
            if (!manager) {
                TryGetComponent(out manager);
            }
        }

        void Awake() {
            instance = this;
        }

        void OnEnable() {
            manager.onPlayerJoined += OnPlayerJoined;
        }

        void OnDisable() {
            manager.onPlayerJoined -= OnPlayerJoined;
        }

        void OnPlayerJoined(PlayerInput input) {
            input.transform.SetParent(playerAnchors[input.playerIndex], false);
        }
    }
}
