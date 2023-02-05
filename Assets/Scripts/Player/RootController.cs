using Rootlesnake.Plants;
using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootController : MonoBehaviour {
        [SerializeField]
        Root m_root = new();

        [SerializeField]
        Vector3 plantOffset = new Vector3(0f, 1f, 0f);

        GrowingPlant growingPlant;

        public IPlant root => m_root;

        void OnEnable() {
            GameManager.onMoveRoots += m_root.Update;
        }
        void OnDisable() {
            GameManager.onMoveRoots -= m_root.Update;
        }

        public void SpawnPlant(int playerIndex, GameObject prefab) {
            m_root.playerIndex = playerIndex;
            m_root.Reset(transform.position);
            var instance = Instantiate(
                prefab,
                transform.position + plantOffset, Quaternion.identity
            );
            m_root.myGrowingPlant = instance.GetComponent<GrowingPlant>();
            m_root.myGrowingPlant.SetColor(m_root.aliveColor);

            AudioManager.instance.PlayAudio(EffectCue.RootGrow);
        }
    }
}
