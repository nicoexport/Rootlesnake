using System;
using UnityEngine;

namespace Rootlesnake.Player {
    [Serializable]
    sealed class RootNode : IPlantNode {
        [SerializeReference]
        IPlantNode m_parent;
        public IPlantNode parent => m_parent;

        public Vector3 position3D { get; set; }
        public Vector2Int position2D => TextureManager.instance.WorldSpaceToPixelSpace(position3D);

        public RootNode(Vector3 position) {
            position3D = position;
        }

        public RootNode CreateChild(Vector3 offset) {
            return new(position3D + offset) {
                m_parent = this
            };
        }
    }
}
