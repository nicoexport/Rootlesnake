using Rootlesnake.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Rootlesnake {
    sealed class PlantSelectDrawer : MonoBehaviour {
        [SerializeField]
        GameObject plantSelectPrefab;

        void OnEnable() {
            PlayerManager.onPlayerJoined += SpawnPlant;
        }

        void OnDisable() {
            PlayerManager.onPlayerJoined -= SpawnPlant;
        }

        void SpawnPlant(HumanIntentions root) {
            var instance = Instantiate(plantSelectPrefab, transform);
            instance.GetComponentInChildren<Image>().sprite = root.config.sprite;
        }
    }
}
