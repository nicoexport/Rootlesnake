using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Rootlesnake.Player {
    sealed class PlayerManager : MonoBehaviour {
        public static PlayerManager instance { get; private set; }

        public static event Action<HumanIntentions> onPlayerJoined;

        [SerializeField]
        PlayerInputManager manager;
        [SerializeField]
        GameObject plantLineupContainer;
        [SerializeField]
        public GameObject firstSelectedButton;
        [SerializeField]
        Transform[] playerAnchors = Array.Empty<Transform>();

        public HashSet<PlayerInput> players = new();

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
            manager.onPlayerLeft += OnPlayerLeft;
        }

        void OnDisable() {
            manager.onPlayerJoined -= OnPlayerJoined;
        }

        void OnPlayerJoined(PlayerInput input) {
            players.Add(input);

            input.transform.SetParent(playerAnchors[input.playerIndex], false);

            var human = input.GetComponent<HumanIntentions>();
            human.config = GameManager.instance.plants[input.playerIndex];

            onPlayerJoined?.Invoke(human);
        }

        void OnPlayerLeft(PlayerInput input) {
            players.Remove(input);
        }
    }
}
