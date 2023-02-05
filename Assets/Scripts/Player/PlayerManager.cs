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

        readonly HashSet<HumanIntentions> players = new();

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

            GameManager.onStartRound += HandleStartRound;
        }

        void OnDisable() {
            manager.onPlayerJoined -= OnPlayerJoined;

            GameManager.onStartRound -= HandleStartRound;
        }

        void OnPlayerJoined(PlayerInput input) {

            input.transform.SetParent(playerAnchors[input.playerIndex], false);

            var human = input.GetComponent<HumanIntentions>();
            human.config = GameManager.instance.plants[input.playerIndex];

            players.Add(human);
            onPlayerJoined?.Invoke(human);
        }

        void OnPlayerLeft(PlayerInput input) {
            players.Remove(input.GetComponent<HumanIntentions>());
        }

        void HandleStartRound() {
            foreach (var player in players) {
                player.SpawnRoot();
            }
        }
    }
}
