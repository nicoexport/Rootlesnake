using DefaultNamespace;
using Rootlesnake.Plants;
using UnityEngine;
using UnityEngine.Events;

namespace Rootlesnake.Player {
    sealed class RootController : MonoBehaviour {
        [SerializeField]
        Root m_root = new();
        
        [SerializeField]
        GrowingPlant growingPlantPrefab;

        [SerializeField] private Vector3 plantOffset = new Vector3(0f, 1f, 0f);

        private GrowingPlant growingPlant;

        public IPlant root => m_root;

        void Start() {
            m_root.Reset(transform.position);
            m_root.myGrowingPlant = Instantiate(growingPlantPrefab, transform.position + plantOffset, Quaternion.identity);
            growingPlant = m_root.myGrowingPlant;
            growingPlant.SetColor(m_root.aliveColor);
            AudioManager.instance.PlayAudio(Audio.RootGrow);
        }

        void OnEnable() {
            GameManager.onMoveRoots += m_root.Update;
        }
        void OnDisable() {
            GameManager.onMoveRoots -= m_root.Update;
        }

        public void SetPlayerIndex(int playerIndex) {
            m_root.playerIndex = playerIndex;
        }
    }
}
