using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootController : MonoBehaviour {
        [SerializeField]
        Root m_root = new();

        public IPlant root => m_root;

        void Start() {
            m_root.Reset(transform.position);
        }

        void FixedUpdate() {
            m_root.Update(Time.deltaTime);
        }
    }
}
