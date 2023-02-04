using System;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class RootNode : IPlantNode {
        [SerializeReference]
        IPlantNode m_parent;
        public IPlantNode parent => m_parent;

        [SerializeField]
        Vector3 m_position;
        public Vector3 position {
            get => m_position;
            set => m_position = value;
        }

        public RootNode(Vector3 position) {
            m_position = position;
        }

        public RootNode CreateChild(Vector3 offset) {
            return new(position + offset) {
                m_parent = this
            };
        }
    }
}
