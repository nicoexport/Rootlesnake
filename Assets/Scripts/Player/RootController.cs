using UnityEngine;

namespace Rootlesnake.Player {
    sealed class RootController : MonoBehaviour {
        [SerializeField]
        Root m_root = new();

        public Root root => m_root;

        void OnEnable() {
            m_root.Reset(transform.position);
        }

        void FixedUpdate() {
            m_root.Update(Time.deltaTime);
        }
    }
}
