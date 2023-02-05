using UnityEngine;

namespace Rootlesnake {
    interface IPlantNode {
        IPlantNode parent { get; }
        Vector3 position3D { get; }
        Vector2Int position2D { get; }
    }
}
