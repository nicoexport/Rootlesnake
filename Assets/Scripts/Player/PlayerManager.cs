using System;
using System.Collections.Generic;
using System.Linq;
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
        GameObject winScreen;
        [SerializeField]
        Transform[] playerAnchors = Array.Empty<Transform>();

        public int totalPlayerCount => players.Count;
        public int livingPlayerCount => players.Count(player => player.isAlive);

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
            GameManager.onStopRound += HandleStopRound;
        }

        void OnDisable() {
            manager.onPlayerJoined -= OnPlayerJoined;

            GameManager.onStartRound -= HandleStartRound;
            GameManager.onStopRound -= HandleStopRound;
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

        bool isRunning = false;

        void HandleStartRound() {
            isRunning = true;
            foreach (var player in players) {
                player.SpawnRoot();
            }
        }

        void Update() {
            if (isRunning) {
                if (totalPlayerCount == 1 && livingPlayerCount == 0) {
                    Debug.Log("Singleplayer Stop");
                    GameManager.instance.StopRound();
                    return;

                }
                if (totalPlayerCount > 1 && livingPlayerCount <= 1) {
                    Debug.Log("MUltiplayerplayer Stop");
                    GameManager.instance.StopRound();
                }
            }
        }

        void HandleStopRound() {
            isRunning = false;
            foreach (var player in players) {
                player.DestroyRoot();
            }
        }
    }
}
