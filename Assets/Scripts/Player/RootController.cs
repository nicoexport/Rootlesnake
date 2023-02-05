using Rootlesnake.Plants;
using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootController : MonoBehaviour {
        [SerializeField]
        Root m_root = new();
        
        [SerializeField]
        GrowingPlant growingPlantPrefab;

        private GrowingPlant growingPlant;

        public IPlant root => m_root;

        void Start() {
            m_root.Reset(transform.position);
            m_root.myGrowingPlant = Instantiate(growingPlantPrefab, transform.position, Quaternion.identity);
            growingPlant = m_root.myGrowingPlant;
            growingPlant.SetColor(m_root.aliveColor);
            Debug.Log("myGrowingPlant");
            Debug.Log(growingPlant);
            Debug.Log(m_root.aliveColor);
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
